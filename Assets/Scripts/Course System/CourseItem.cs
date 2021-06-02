using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Course_System
{
  /// <summary>
  /// A ScriptableObject that represents any course
  /// </summary>
  [CreateAssetMenu(fileName = "new course", menuName = "Courses/newCourse")]
  public class CourseItem : ScriptableObject, ISerializationCallbackReceiver
  {

    // CONFIG DATA
    [Tooltip("Auto-generated UUID for saving/loading. Clear this field if you want to generate a new one.")]
    [SerializeField] string itemID = null;

    // [Tooltip("The UI icon to represent this item in the inventory.")]
    // [SerializeField] Sprite icon = null;
    [SerializeField] string courseText = null;


    [Tooltip("Course name to be displayed in UI.")]
    public string courseName;

    [Tooltip("Course description to be displayed in UI.")]
    [SerializeField][TextArea] string description = null;

    //public int classLevel;
    public List<Stats> listOfStats; //len 3



        // STATE, id to courseItem
        static Dictionary<string, CourseItem> itemLookupCache;

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
        public static CourseItem GetFromID(string itemID)
        {
            if (itemLookupCache == null)
            {
                itemLookupCache = new Dictionary<string, CourseItem>();
                var itemList = Resources.LoadAll<CourseItem>("");
                foreach (var item in itemList)
                {
                    if (itemLookupCache.ContainsKey(item.itemID))
                    {
                        Debug.LogError(
                          $"Looks like there's a duplicate GameDevTV.UI.InventorySystem ID for objects: {itemLookupCache[item.itemID]} and {item}");
                        continue;
                    }

                    itemLookupCache[item.itemID] = item;
                }
            }

            if (itemID == null || !itemLookupCache.ContainsKey(itemID)) return null;
            return itemLookupCache[itemID];
        }

        /*public Sprite GetIcon()
        {
            return icon;
        }*/

        public string GetItemID()
        {
            return itemID;
        }


        public string GetCourseName()
        {
            return courseName;
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



