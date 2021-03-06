using System.Collections;
using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.UI.Inventories;
using GameDev.tv_Assets.Scripts.Utils.UI.Dragging;
using UnityEngine;
using UnityEngine.UI;
using GameDevTV.Core.UI.Dragging;
using GameDevTV.Inventories;

namespace GameDevTV.UI.Inventories
{
    /// <summary>
    /// An slot for the players equipment.
    /// </summary>
    public class EquipmentSlotUI : MonoBehaviour, IItemHolder, IDragContainer<InventoryItem>
    {
        // CONFIG DATA

        [SerializeField] InventoryItemIconInChild iconInChild = null;
        [SerializeField] EquipLocation equipLocation = EquipLocation.Weapon;

        // CACHE
        Equipment playerEquipment;

        // LIFECYCLE METHODS
       
        private void Awake() 
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            playerEquipment = player.GetComponent<Equipment>();
            playerEquipment.equipmentUpdated += RedrawUI;
        }

        private void Start() 
        {
            RedrawUI();
        }

        // PUBLIC

        public int MaxAcceptable(InventoryItem item)
        {
            EquipableItem equipableItem = item as EquipableItem;
            if (equipableItem == null) return 0;
            if (equipableItem.GetAllowedEquipLocation() != equipLocation) return 0;
            if (GetItem() != null) return 0;

            return 1;
        }

        public void AddItems(InventoryItem item, int number)
        {
            playerEquipment.AddItem(equipLocation, (EquipableItem) item);
        }

        public InventoryItem GetItem()
        {
            return playerEquipment.GetItemInSlot(equipLocation);
        }

        public int GetNumber()
        {
            if (GetItem() != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void RemoveItems(int number)
        {
            playerEquipment.RemoveItem(equipLocation);
        }

        // PRIVATE

        void RedrawUI()
        {
            iconInChild.SetItem(playerEquipment.GetItemInSlot(equipLocation));
        }
    }
}