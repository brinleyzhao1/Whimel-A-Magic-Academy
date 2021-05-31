﻿using GameDev.tv_Assets.Scripts.Inventories;
using GameDevTV.Inventories;
using TMPro;
using UnityEngine;

namespace GameDev.tv_Assets.Scripts.UI.Inventories
{
    /// <summary>
    /// Root of the tooltip prefab to expose properties to other classes.
    /// </summary>
    public class ItemTooltip : MonoBehaviour
    {
        // CONFIG DATA
        [SerializeField] TextMeshProUGUI titleText = null;
        [SerializeField] TextMeshProUGUI bodyText = null;

        // PUBLIC

        public void Setup(InventoryItem item)
        {
            titleText.text = item.GetDisplayName();
            bodyText.text = item.GetDescription();
        }

        public void SetupOnlyText(string text)
        {
          bodyText.text = text;
        }
    }
}
