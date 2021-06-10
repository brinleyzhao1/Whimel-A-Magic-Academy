using System;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Course_System
{
  /// <summary>
  /// A ScriptableObject that represents any course
  /// </summary>
  [CreateAssetMenu(fileName = "new course", menuName = "Scriptables/newCourse")]
  public class CourseItem : ScriptableObject
  {
    // CONFIG DATA
    // [Tooltip("Auto-generated UUID for saving/loading. Clear this field if you want to generate a new one.")]
    // [SerializeField] string itemId = null;

    // [Tooltip("The UI icon to represent this item in the inventory.")]
    // [SerializeField] Sprite icon = null;
    // [SerializeField] string courseText = null;


    // [Tooltip("Course name to be displayed in UI.")]
    // public string courseName;

    [Tooltip("Course description to be displayed in UI.")] [SerializeField] [TextArea]
    string description = null;


    [Serializable]
    public struct StatChange
    {
      public Stats stat;
      public int valueChange;
    }

    public StatChange[] statsChange = new StatChange[4];


    // STATE, id to courseItem
    // static Dictionary<string, CourseItem> _itemLookupCache;


    // PUBLIC


    /// <summary>
    /// Get the inventory item instance from its UUID.
    /// </summary>
    /// <param name="itemId">
    /// String UUID that persists between game instances.
    /// </param>
    /// <returns>
    /// Inventory item instance corresponding to the ID.
    /// </returns>
    // public static CourseItem GetFromId(string itemId)
    // {
    //     if (itemLookupCache == null)
    //     {
    //         itemLookupCache = new Dictionary<string, CourseItem>();
    //         var itemList = Resources.LoadAll<CourseItem>("");
    //         foreach (var item in itemList)
    //         {
    //             if (itemLookupCache.ContainsKey(item.itemId))
    //             {
    //                 Debug.LogError(
    //                   $"Looks like there's a duplicate GameDevTV.UI.InventorySystem ID for objects: {itemLookupCache[item.itemId]} and {item}");
    //                 continue;
    //             }
    //
    //             itemLookupCache[item.itemId] = item;
    //         }
    //     }
    //
    //     if (itemId == null || !itemLookupCache.ContainsKey(itemId)) return null;
    //     return itemLookupCache[itemId];
    // }

    /*public Sprite GetIcon()
    {
        return icon;
    }*/

    // public string GetItemID()
    // {
    //     return itemId;
    // }
    //
    //
    // public string GetCourseName()
    // {
    //     return courseName;
    // }

    // public string GetDescription()
    // {
    //     return description;
    // }

    // PRIVATE

    // void ISerializationCallbackReceiver.OnBeforeSerialize()
    // {
    //     // Generate and save a new UUID if this is blank.
    //     if (string.IsNullOrWhiteSpace(itemId))
    //     {
    //         itemId = System.Guid.NewGuid().ToString();
    //     }
    // }

    // void ISerializationCallbackReceiver.OnAfterDeserialize()
    // {
    //     // Require by the ISerializationCallbackReceiver but we don't need
    //     // to do anything with it.
    // }
  }
}
