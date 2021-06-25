using System;
using GameDev.tv_Assets.Scripts.Saving;
using UnityEngine;

namespace GameDev.tv_Assets.Scripts.Inventories
{
  /// <summary>
  /// Provides storage for the player inventory. A configurable number of
  /// slots are available.
  ///
  /// This component should be placed on the GameObject tagged "Player".
  /// </summary>
  public class Inventory : MonoBehaviour, ISaveable
  {
    // CONFIG DATA
    [Tooltip("Allowed size")] [SerializeField]
    int inventorySize = 16;

    // STATE, the actual inventory
    InventorySlot[] slots;

    public struct InventorySlot
    {
      public InventoryItem Item;
      public int Number;
    }

    private void Awake()
    {
      slots = new InventorySlot[inventorySize];
    }
    // PUBLIC

    /// <summary>
    /// Broadcasts when the items in the slots are added/removed.
    /// </summary>
    public event Action InventoryUpdated;

    #region Functions Related to Inventory

    /// <summary>
    /// Convenience for getting the player's inventory.
    /// </summary>
    public static Inventory GetPlayerInventory()
    {
      var player = GameObject.FindWithTag("Player");
      return player.GetComponent<Inventory>();
    }

    /// <summary>
    /// Could this item fit anywhere in the inventory?
    /// </summary>
    public bool HasSpaceFor(InventoryItem item)
    {
      return FindSlot(item) >= 0;
    }

    /// <summary>
    /// How many slots are in the inventory?
    /// </summary>
    public int GetSize()
    {
      return slots.Length;
    }

    /// <summary>
    /// Attempt to add the items to the first available slot.
    /// </summary>
    /// <param name="item">The item to add.</param>
    /// <param name="number">The number to add.</param>
    /// <returns>Whether or not the item could be added.</returns>
    public bool AddToFirstEmptySlot(InventoryItem item, int number)
    {
      int i = FindSlot(item);

      if (i < 0)
      {
        return false;
      }

      slots[i].Item = item;
      slots[i].Number += number;
      InventoryUpdated?.Invoke();

      return true;
    }

    /// <summary>
    /// Is there an instance of the item in the inventory?
    /// </summary>
    public bool HasItem(InventoryItem item)
    {
      for (int i = 0; i < slots.Length; i++)
      {
        if (object.ReferenceEquals(slots[i].Item, item))
        {
          return true;
        }
      }

      return false;
    }

    /// <summary>
    /// return total amount of a type of item in possession
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int TotalAmountHad(InventoryItem item)
    {
      if (!HasItem(item))
      {
        return 0;
      }

      int total = 0;
      for (int i = 0; i < slots.Length; i++)
      {
        if (object.ReferenceEquals(slots[i].Item, item))
        {
          total += slots[i].Number;
        }
      }

      return total;

    }

    /// <summary>
    /// Return the item type in the given slot.
    /// </summary>
    public InventoryItem GetItemInSlot(int slot)
    {
      return slots[slot].Item;
    }

    /// <summary>
    /// Get the number of items in the given slot.
    /// </summary>
    public int GetNumberInSlot(int slot)
    {
      return slots[slot].Number;
    }

    /// <summary>
    /// Remove a number of items from the given slot. Will never remove more
    /// that there are.
    /// </summary>
    public void RemoveFromSlot(int slot, int number)
    {
      slots[slot].Number -= number;
      if (slots[slot].Number <= 0)
      {
        slots[slot].Number = 0;
        slots[slot].Item = null;
      }

      if (InventoryUpdated != null)
      {
        InventoryUpdated();
      }
    }

    /// <summary>
    /// Will add an item to the given slot if possible. If there is already
    /// a stack of this type, it will add to the existing stack. Otherwise,
    /// it will be added to the first empty slot.
    /// </summary>
    /// <param name="slot">The slot to attempt to add to.</param>
    /// <param name="item">The item type to add.</param>
    /// <param name="number">The number of items to add.</param>
    /// <returns>True if the item was added anywhere in the inventory.</returns>
    public bool AddItemToSlot(int slot, InventoryItem item, int number)
    {
      if (slots[slot].Item != null)
      {
        return AddToFirstEmptySlot(item, number);
        ;
      }

      var i = FindStack(item);
      if (i >= 0)
      {
        slot = i;
      }

      slots[slot].Item = item;
      slots[slot].Number += number;
      if (InventoryUpdated != null)
      {
        InventoryUpdated();
      }

      return true;
    }

    // PRIVATE


    /// <summary>
    /// Find a slot that can accomodate the given item.
    /// </summary>
    /// <returns>-1 if no slot is found.</returns>
    private int FindSlot(InventoryItem item)
    {
      int i = FindStack(item);
      if (i < 0)
      {
        i = FindEmptySlot();
      }

      return i;
    }

    /// <summary>
    /// Find an empty slot.
    /// </summary>
    /// <returns>-1 if all slots are full.</returns>
    private int FindEmptySlot()
    {
      for (int i = 0; i < slots.Length; i++)
      {
        if (slots[i].Item == null)
        {
          return i;
        }
      }

      return -1;
    }

    /// <summary>
    /// Find an existing stack of this item type.
    /// </summary>
    /// <returns>-1 if no stack exists or if the item is not stackable.</returns>
    private int FindStack(InventoryItem item)
    {
      if (!item.IsStackable())
      {
        return -1;
      }

      for (int i = 0; i < slots.Length; i++)
      {
        if (object.ReferenceEquals(slots[i].Item, item))
        {
          return i;
        }
      }

      return -1;
    }

    #endregion

    #region Saving

    [System.Serializable]
    private struct InventorySlotRecord
    {
      public string itemId;
      public int number;
    }

    object ISaveable.CaptureState()
    {
      var slotStrings = new InventorySlotRecord[inventorySize];
      for (int i = 0; i < inventorySize; i++)
      {
        if (slots[i].Item != null)
        {
          slotStrings[i].itemId = slots[i].Item.GetItemID();
          slotStrings[i].number = slots[i].Number;
        }
      }

      return slotStrings;
    }

    void ISaveable.RestoreState(object state)
    {
      var slotStrings = (InventorySlotRecord[]) state;
      for (int i = 0; i < inventorySize; i++)
      {
        slots[i].Item = InventoryItem.GetFromID(slotStrings[i].itemId);
        slots[i].Number = slotStrings[i].number;
      }

      if (InventoryUpdated != null)
      {
        InventoryUpdated();
      }
    }

    #endregion
  }
}
