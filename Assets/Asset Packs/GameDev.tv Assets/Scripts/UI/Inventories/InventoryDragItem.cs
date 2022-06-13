using System.Collections;
using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Inventories;
using UnityEngine;
using GameDevTV.Core.UI.Dragging;
using GameDevTV.Inventories;

namespace GameDevTV.UI.Inventories
{
    /// <summary>
    /// To be placed on icons representing the item in a slot. Allows the item
    /// to be dragged into other slots.
    /// </summary>
    public class InventoryDragItem : DragItem<InventoryItem>
    {
    }
}