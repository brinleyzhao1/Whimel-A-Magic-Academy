using System;
using GameDev.tv_Assets.Scripts.UI.Inventories;
using GameDevTV.Inventories;
using Player;
using Player.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Shop
{
  public class SellItem : MonoBehaviour, IPointerClickHandler
  {
    // PRIVATE STATE
    Transform sellButton = null;

    public InventorySlotUi inventorySlotUi;
    private TMP_Text priceText;
    private Image sellingTrayItemImage;


    private void Start()
    {
      inventorySlotUi = GetComponent<InventorySlotUi>();

      priceText = GameAssets.SellingTray.transform.Find("price text").GetComponent<TMP_Text>();

      sellButton = GameAssets.SellingTray.transform.Find("sell button");

      sellingTrayItemImage = GameAssets.SellingTray.transform.Find("sell tray box/sell item image")
        .GetComponent<Image>();
    }


    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
      if (GameAssets.ShopPanel.activeSelf)
      {
        GameAssets.SellingTray.SetActive(true);
        UpdateSellTray();
      }
    }

    private void UpdateSellTray()
    {
      sellButton.GetComponent<SellButtonUi>().index = inventorySlotUi.index;


      sellingTrayItemImage.sprite = inventorySlotUi.GetItem().GetIcon();
      sellingTrayItemImage.enabled = true;

      priceText.text = inventorySlotUi.GetItem().sellingPrice.ToString();

      sellButton.GetComponent<Image>().color = Color.white;
      sellButton.GetComponent<Button>().enabled = true;
    }
  }
}
