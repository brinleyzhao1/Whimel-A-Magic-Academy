using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev.tv_Assets.Scripts.Inventories
{
  /// <summary>
  /// A ScriptableObject that represents any item that can be put in an
  /// inventory.
  /// </summary>
  /// <remarks>
  /// In practice, you are likely to use a subclass such as `ActionScriptableItem` or
  /// `EquipableItem`.
  /// </remarks>
  // [Serializable]
  public abstract class InventoryItem : ScriptableObject, ISerializationCallbackReceiver
  {
    // CONFIG DATA
    [Tooltip("Item name to be displayed in UI.")] [SerializeField]
    string displayName = null;

    [Tooltip("Auto-generated UUID for saving/loading. Clear this field if you want to generate a new one.")]
    [SerializeField]
    string itemID = null;

    [Tooltip("Price of this item when player buys it at a store.")] [SerializeField]
    public int buyingPrice = 10;

    [Tooltip("Item name to be displayed in UI.")] [SerializeField]
    public int sellingPrice = 10;

    [Tooltip("Item description to be displayed in UI.")] [SerializeField] [TextArea]
    string description = null;

    [Tooltip("The UI icon to represent this item in the inventory.")] [SerializeField]
    Sprite icon = null;

    [Tooltip("The prefab that should be spawned when this item is dropped.")] [SerializeField]
    Pickup inGame3DPickup = null;

    [Tooltip("If true, multiple items of this type can be stacked in the same inventory slot.")] [SerializeField]
    bool stackable = false;

    // [Tooltip("Can an instance of this item be consumed to make potion")]
    // [SerializeField] public bool isPotionIngredient = false;
    // [Tooltip("Can an instance of this item be consumed to make weapons and such")]
    // [SerializeField] public bool isForgeIngredient = false;

    // [ExecuteInEditMode]


    // STATE
    static Dictionary<string, InventoryItem> itemLookupCache;

    // PUBLIC

    /// <summary>
    /// Get the inventory item instance from its UUID.
    /// </summary>
    /// <param name="itemID">
    /// String UUID that persists between game instances.
    /// </param>
    /// <returns>
    /// Inventory item instance corresponding to the ID.
    /// </returns>
    public static InventoryItem GetFromID(string itemID)
    {
      if (itemLookupCache == null)
      {
        itemLookupCache = new Dictionary<string, InventoryItem>();
        var itemList = Resources.LoadAll<InventoryItem>("");
        foreach (var item in itemList)
        {
          if (itemLookupCache.ContainsKey(item.itemID))
          {
            Debug.LogError(string.Format(
              "Looks like there's a duplicate GameDevTV.UI.InventorySystem ID for objects: {0} and {1}",
              itemLookupCache[item.itemID], item));
            continue;
          }

          itemLookupCache[item.itemID] = item;
        }
      }

      if (itemID == null || !itemLookupCache.ContainsKey(itemID)) return null;
      return itemLookupCache[itemID];
    }

    /// <summary>
    /// Spawn the inGame3DPickup gameobject into the world.
    /// </summary>
    /// <param name="position">Where to spawn the inGame3DPickup.</param>
    /// <param name="number">How many instances of the item does the inGame3DPickup represent.</param>
    /// <returns>Reference to the inGame3DPickup object spawned.</returns>
    public Pickup SpawnPickup(Vector3 position, int number)
    {
      var pickup = Instantiate(this.inGame3DPickup);
      pickup.transform.position = position;
      pickup.Setup(this, number);
      return pickup;
    }

    public Sprite GetIcon()
    {
      return icon;
    }

    public string GetItemID()
    {
      return itemID;
    }

    public bool IsStackable()
    {
      return stackable;
    }

    public string GetDisplayName()
    {
      return displayName;
    }

    public string GetDescription()
    {
      return description;
    }

    // PRIVATE

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
      // Generate and save a new UUID if this is blank.
      if (string.IsNullOrWhiteSpace(itemID))
      {
        itemID = System.Guid.NewGuid().ToString();
      }
    }

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
      // Require by the ISerializationCallbackReceiver but we don't need
      // to do anything with it.
    }
  }
}
