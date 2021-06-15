﻿using GameDev.tv_Assets.Scripts.Inventories;

namespace GameDev.tv_Assets.Scripts.UI.Inventories
{
    /// <summary>
    /// Allows the `ItemTooltipSpawner` to display the right information.
    /// </summary>
    public interface IItemHolder
    {
        InventoryItem GetItem();
    }
}
