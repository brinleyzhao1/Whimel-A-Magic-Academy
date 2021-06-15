﻿using System;
using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Saving;
using GameDevTV.Inventories;
using GameDevTV.Saving;
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
    // private int currentIndexSelected;


    // STATE
    Dictionary<int, DockedItemSlot> dockedItems = new Dictionary<int, DockedItemSlot>();

    private class DockedItemSlot
    {
      public ActionItem ActionBarItem;
      public int ActionBarNumber;
    }

    private void Update()
    {
      //if press a number key, select that action slot

      for (int i = 0; i < maxIndexOfActionSlot; ++i)
      {
        if (Input.GetKeyDown("" + i))
        {
          // currentIndexSelected = i;
          // visual highlight that slot
          bool canBeUsed = Use(i - 1, GameObject.FindWithTag("Player"));
        }
      }
    }
    // PUBLIC

    /// <summary>
    /// Broadcasts when the items in the slots are added/removed.
    /// </summary>
    public event Action StoreUpdated;

    /// <summary>
    /// Get the action at the given index.
    /// </summary>
    public ActionItem GetAction(int index)
    {
      if (dockedItems.ContainsKey(index))
      {
        return dockedItems[index].ActionBarItem;
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
    public void AddAction(InventoryItem item, int index, int number)
    {
      if (dockedItems.ContainsKey(index))
      {
        if (object.ReferenceEquals(item, dockedItems[index].ActionBarItem))
        {
          dockedItems[index].ActionBarNumber += number;
        }
      }
      else
      {
        var slot = new DockedItemSlot();
        slot.ActionBarItem = item as ActionItem;
        slot.ActionBarNumber = number;
        dockedItems[index] = slot;
      }

      if (StoreUpdated != null)
      {
        StoreUpdated();
      }

    }

    /// <summary>
    /// Use the item at the given slot. If the item is consumable one
    /// instance will be destroyed until the item is removed completely.
    /// </summary>
    /// <param name="user">The character that wants to use this action.</param>
    /// <returns>False if the action could not be executed.</returns>
    public bool Use(int index, GameObject user)
    {
      if (dockedItems.ContainsKey(index))
      {
        dockedItems[index].ActionBarItem.Use(user);
        if (dockedItems[index].ActionBarItem.IsConsumable())
        {
          RemoveItems(index, 1);
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

        if (StoreUpdated != null)
        {
          StoreUpdated();
        }
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
      var actionItem = item as ActionItem;
      if (!actionItem) return 0;

      if (dockedItems.ContainsKey(index) && !object.ReferenceEquals(item, dockedItems[index].ActionBarItem))
      {
        return 0;
      }

      if (actionItem.IsConsumable())
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

    /// PRIVATE
    [System.Serializable]
    private struct DockedItemRecord
    {
      public string itemID;
      public int number;
    }

    object ISaveable.CaptureState()
    {
      var state = new Dictionary<int, DockedItemRecord>();
      foreach (var pair in dockedItems)
      {
        var record = new DockedItemRecord();
        record.itemID = pair.Value.ActionBarItem.GetItemID();
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
        AddAction(InventoryItem.GetFromID(pair.Value.itemID), pair.Key, pair.Value.number);
      }
    }

    #endregion
  }
}
