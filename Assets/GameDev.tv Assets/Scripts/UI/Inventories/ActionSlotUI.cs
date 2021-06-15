using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.Utils.UI.Dragging;
using GameDevTV.Core.UI.Dragging;
using GameDevTV.Inventories;
using GameDevTV.UI.Inventories;
using UnityEngine;

namespace GameDev.tv_Assets.Scripts.UI.Inventories
{
    /// <summary>
    /// The UI slot for the player action bar.
    /// </summary>
    public class ActionSlotUi : MonoBehaviour, IItemHolder, IDragContainer<InventoryItem>
    {
        // CONFIG DATA
        [SerializeField] InventoryItemIconInChild iconInChild = null;
        [SerializeField] int index = 0;

        // CACHE
        ActionStore actionStore;

        // LIFECYCLE METHODS
        private void Awake()
        {
            actionStore = GameObject.FindGameObjectWithTag("Player").GetComponent<ActionStore>();
            actionStore.StoreUpdated += UpdateIcon;
        }

        // PUBLIC

        public void AddItems(InventoryItem item, int number)
        {
            actionStore.AddAction(item, index, number);
        }

        public InventoryItem GetItem()
        {
            return actionStore.GetAction(index);
        }

        public int GetNumber()
        {
            return actionStore.GetNumber(index);
        }

        public int MaxAcceptable(InventoryItem item)
        {
            return actionStore.MaxAcceptable(item, index);
        }

        public void RemoveItems(int number)
        {
            actionStore.RemoveItems(index, number);
        }

        // PRIVATE

        void UpdateIcon()
        {
            iconInChild.SetItem(GetItem(), GetNumber());
        }
    }
}
