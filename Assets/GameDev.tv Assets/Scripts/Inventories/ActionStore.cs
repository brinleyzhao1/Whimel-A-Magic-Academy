using System;
using System.Collections.Generic;
using Alchemy;
using GameDev.tv_Assets.Scripts.Saving;
using UnityEngine;

namespace GameDev.tv_Assets.Scripts.Inventories
{
  /// <summary>
  /// Provides the storage for an action bar. The bar has a finite number of
  /// slots that can be filled and actions in the slots can be "used".
  ///
  /// This component should be placed on the GameObject tagged "Player".
  /// </summary>
  public class ActionStore : MonoBehaviour, ISaveable
  {
    private int maxIndexOfActionSlot = 6;
    public int currentIndexSelected = 18;


    // STATE
    Dictionary<int, DockedItemSlot> dockedItems = new Dictionary<int, DockedItemSlot>();

    private class DockedItemSlot
    {
      public ActionScriptableItem ActionScriptableBarItem;
      public int ActionBarNumber;
    }


    private void Update()
    {
      //if press a number key, select that action slot
      SelectAndUse();
    }

    private void SelectAndUse()
    {
      for (int i = 0; i < maxIndexOfActionSlot + 1; ++i)
      {
        if (Input.GetKeyDown("" + i))
        {
          currentIndexSelected = i - 1;
          //use that item
          bool canBeUsed = ActionStoreUse(i - 1, GameObject.FindWithTag("Player"));

          StoreUpdated?.Invoke();
          //todo if click the same key again, deselect that slot
        }
      }
    }

    /// <summary>
    /// Broadcasts when the items in the slots are added/removed.
    /// </summary>
    public event Action StoreUpdated;

    /// <summary>
    /// Get the action at the given index.
    /// </summary>
    public ActionScriptableItem GetActionItem(int index)
    {
      if (dockedItems.ContainsKey(index))
      {
        return dockedItems[index].ActionScriptableBarItem;
      }

      return null;
    }

    /// <summary>
    /// Get the number of items left at the given index.
    /// </summary>
    /// <returns>
    /// Will return 0 if no item is in the index or the item has
    /// been fully consumed.
    /// </returns>
    public int GetNumber(int index)
    {
      if (dockedItems.ContainsKey(index))
      {
        return dockedItems[index].ActionBarNumber;
      }

      return 0;
    }

    /// <summary>
    /// Add an item to the given index.
    /// </summary>
    /// <param name="item">What item should be added.</param>
    /// <param name="index">Where should the item be added.</param>
    /// <param name="number">How many items to add.</param>
    public void AddActionItem(InventoryItem item, int index, int number)
    {
      if (dockedItems.ContainsKey(index))
      {
        if (object.ReferenceEquals(item, dockedItems[index].ActionScriptableBarItem))
        {
          dockedItems[index].ActionBarNumber += number;
        }
      }
      else
      {
        var slot = new DockedItemSlot
        {
          ActionScriptableBarItem = item as ActionScriptableItem, ActionBarNumber = number
        };
        dockedItems[index] = slot;
      }

      StoreUpdated?.Invoke();
    }

    /// <summary>
    /// ActionStoreUse the item at the given slot. If the item is consumable one
    /// instance will be destroyed until the item is removed completely.
    /// </summary>
    /// <param name="user">The character that wants to use this action.</param>
    /// <returns>False if the action could not be executed.</returns>
    private bool ActionStoreUse(int index, GameObject user)
    {
      if (dockedItems.ContainsKey(index))
      {
        var thisItem = dockedItems[index].ActionScriptableBarItem;

        thisItem.Use(user);
        if (thisItem.IsConsumable())
        {
          RemoveItems(index, 1);
        }


        if (thisItem.GetType() == typeof(PotionRecipeScriptableObject))
        {
          var thisIsAPotionRecipe = (PotionRecipeScriptableObject) thisItem;
          if (!Alchemy.Alchemy.Instance.AlreadyKnownThisRecipe(thisIsAPotionRecipe))
          {
            Alchemy.Alchemy.Instance.AddNewPotionRecipe(thisIsAPotionRecipe);
            RemoveItems(index, 1);
          }
          else
          {
            //not consume this recipe
          }
        }

        return true;
      }

      return false;
    }

    /// <summary>
    /// Remove a given number of items from the given slot.
    /// </summary>
    public void RemoveItems(int index, int number)
    {
      if (dockedItems.ContainsKey(index))
      {
        dockedItems[index].ActionBarNumber -= number;
        if (dockedItems[index].ActionBarNumber <= 0)
        {
          dockedItems.Remove(index);
        }

        StoreUpdated?.Invoke();
      }
    }

    /// <summary>
    /// What is the maximum number of items allowed in this slot.
    ///
    /// This takes into account whether the slot already contains an item
    /// and whether it is the same type. Will only accept multiple if the
    /// item is consumable.
    /// </summary>
    /// <returns>Will return int.MaxValue when there is not effective bound.</returns>
    public int MaxAcceptable(InventoryItem item, int index)
    {
      var actionItem = item as ActionScriptableItem;
      if (!actionItem) return 0;

      if (dockedItems.ContainsKey(index) && !object.ReferenceEquals(item, dockedItems[index].ActionScriptableBarItem))
      {
        return 0;
      }

      if (actionItem != null && actionItem.IsConsumable())
      {
        return int.MaxValue;
      }

      if (dockedItems.ContainsKey(index))
      {
        return 0;
      }

      return 1;
    }


    #region Saving

    //todo add currentSelectedItem to saves

    /// PRIVATE
    [Serializable]
    private struct DockedItemRecord
    {
      public string itemId;
      public int number;
    }

    object ISaveable.CaptureState()
    {
      var state = new Dictionary<int, DockedItemRecord>();
      foreach (var pair in dockedItems)
      {
        var record = new DockedItemRecord();
        record.itemId = pair.Value.ActionScriptableBarItem.GetItemID();
        record.number = pair.Value.ActionBarNumber;
        state[pair.Key] = record;
      }

      return state;
    }

    void ISaveable.RestoreState(object state)
    {
      var stateDict = (Dictionary<int, DockedItemRecord>) state;
      foreach (var pair in stateDict)
      {
        AddActionItem(InventoryItem.GetFromID(pair.Value.itemId), pair.Key, pair.Value.number);
      }
    }

    #endregion
  }
}
