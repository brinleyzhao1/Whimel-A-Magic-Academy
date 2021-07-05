using System;
using System.Collections.Generic;
using System.Data;
using Player;
using Stats;
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
    [Tooltip("Auto-generated UUID for saving/loading. Clear this field if you want to generate a new one.")]
    [SerializeField] string courseId = null;


    [Tooltip("Course description to be displayed in UI.")] [SerializeField] [TextArea]
    string description = null;


    public StatsType[] statsIncreased = new StatsType[1];
    public StatsType statDecreased ;

    // STATE, id to courseItem
    // static Dictionary<string, CourseItem> _itemLookupCache;


    // PUBLIC


    /// <summary>
    /// Get the inventory item instance from its UUID.
    /// </summary>
    /// <param name="courseId">
    /// String UUID that persists between game instances.
    /// </param>
    /// <returns>
    /// Inventory item instance corresponding to the ID.
    /// </returns>
    // public static CourseItem GetFromId(string courseId)
    // {
    //     if (itemLookupCache == null)
    //     {
    //         itemLookupCache = new Dictionary<string, CourseItem>();
    //         var itemList = Resources.LoadAll<CourseItem>("");
    //         foreach (var item in itemList)
    //         {
    //             if (itemLookupCache.ContainsKey(item.courseId))
    //             {
    //                 Debug.LogError(
    //                   $"Looks like there's a duplicate GameDevTV.UI.InventorySystem ID for objects: {itemLookupCache[item.courseId]} and {item}");
    //                 continue;
    //             }
    //
    //             itemLookupCache[item.courseId] = item;
    //         }
    //     }
    //
    //     if (courseId == null || !itemLookupCache.ContainsKey(courseId)) return null;
    //     return itemLookupCache[courseId];
    // }

    /*public Sprite GetIcon()
    {
        return icon;
    }*/

    // public string GetItemID()
    // {
    //     return courseId;
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
    //     if (string.IsNullOrWhiteSpace(courseId))
    //     {
    //         courseId = System.Guid.NewGuid().ToString();
    //     }
    // }

    // void ISerializationCallbackReceiver.OnAfterDeserialize()
    // {
    //     // Require by the ISerializationCallbackReceiver but we don't need
    //     // to do anything with it.
    // }
  }
}
