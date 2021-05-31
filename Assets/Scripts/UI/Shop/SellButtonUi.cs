using System;
using GameDev.tv_Assets.Scripts.UI.Inventories;
using GameDevTV.Inventories;
using Player;
using Player.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Shop
{
  public class SellButtonUi : MonoBehaviour
  {

    public int index;
    private Image sellingTrayItemImage;
    private TMP_Text priceText;

    private void Start()
    {
      sellingTrayItemImage = GameAssets.SellingTray.transform.Find("sell tray box/sell item image")
        .GetComponent<Image>();
      priceText = GameAssets.SellingTray.transform.Find("price text").GetComponent<TMP_Text>();
    }

    public void SellButtonFunction() // for sell button
    {
      // print("index is "+index);

      FindObjectOfType<Money>().AddOrMinusMoney(Inventory.GetPlayerInventory().GetItemInSlot(index).sellingPrice);
      Inventory.GetPlayerInventory().RemoveFromSlot(index, 1);


      if (Inventory.GetPlayerInventory().GetNumberInSlot(index) == 0)
      {
        sellingTrayItemImage.enabled = false;
        GetComponent<Image>().color = Color.gray;

        GetComponent<Button>().enabled = false;
        priceText.text = "";
      }

    }
  }
}
