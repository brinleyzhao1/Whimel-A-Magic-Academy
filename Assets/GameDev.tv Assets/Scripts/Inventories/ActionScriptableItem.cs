using GameDevTV.Inventories;
using Player;
using UnityEngine;

namespace GameDev.tv_Assets.Scripts.Inventories
{
    /// <summary>
    /// An inventory item that can be placed in the action bar and "Used".
    /// actionItem is currently define as all items that can be consumed in some way.
    /// so far it means ingredients, potions and food
    /// </summary>
    /// <remarks>
    /// This class should be used as a base. Subclasses must implement the `Use` method.
    /// </remarks>
    [CreateAssetMenu(menuName = ("Items/Action Item"))]
    public class ActionScriptableItem : InventoryItem
    {
        // CONFIG DATA
        [Tooltip("Does an instance of this item get consumed every time it's used.")]
        [SerializeField] bool directlyConsumable = false;

        [Tooltip("Does an instance of this item get consumed every time it's used.")]
        [SerializeField] int energyChange = 0;
        // PUBLIC

        /// <summary>
        /// Trigger the use of this item. Override to provide functionality.
        /// </summary>
        /// <param name="user">The character that is using this action.</param>
        public void Use(GameObject user)
        {
            // Debug.Log("Using action: " + this);
            PlayerEnergy player = FindObjectOfType<PlayerEnergy>();
            player.UpdateEnergyByValue(energyChange);
        }

        public bool IsConsumable()
        {
            return directlyConsumable;
        }


    }
}