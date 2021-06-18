using System;
using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.UI.Inventories;
using Player;
using Player.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Shop
{
  /// <summary>
  ///sit on sell tray (UI)
  /// there should only exist one copy
  /// </summary>
  public class SellTray : MonoBehaviour
  {

    #region Singleton

    private static SellTray _instance;

    public static SellTray Instance
    {
      get { return _instance; }
    }


    private void Awake()
    {
      if (_instance != null && _instance != this)
      {
        Destroy(this.gameObject);
      }
      else
      {
        _instance = this;
      }
    }

    #endregion


    // PRIVATE STATE
    [Tooltip("in child")] [SerializeField] private InventorySlotUi sellSlotUi; //in child
    [SerializeField] private TextMeshProUGUI priceText;

    private int indexInInventorySelected;
    private int totalValueToBeExchanged;

    Inventory inventory;

    private void Start()
    {
      // sellSlotUi = GetComponent<InventorySlotUi>();
      inventory = Inventory.GetPlayerInventory();

    }

    public void ButtonSellFunction() // for sell button
    {
      // print("index is "+index);

      FindObjectOfType<Money>().AddOrMinusMoney(totalValueToBeExchanged);
      Inventory.GetPlayerInventory().RemoveFromSlot(indexInInventorySelected, inventory.GetNumberInSlot(indexInInventorySelected));

      UpdateSellTray();

      // if (Inventory.GetPlayerInventory().GetNumberInSlot(indexInInventorySelected) == 0)
      // {
      //   sellingTrayItemImage.enabled = false;
      //   GetComponent<Image>().color = Color.gray;
      //
      //   GetComponent<Button>().enabled = false;
      //   priceText.text = "";
      // }
    }

    public void ReceiveInfoAboutSelectedItemForSell(int index)
    {
      indexInInventorySelected = index;
      totalValueToBeExchanged = inventory.GetItemInSlot(index).sellingPrice * inventory.GetNumberInSlot(index);
      UpdateSellTray();
    }


    // void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    // {
    //   if (GameAssets.ShopPanel.activeSelf)
    //   {
    //     GameAssets.SellingTray.SetActive(true);
    //     UpdateSellTray();
    //   }
    // }

    // }
    public void ClearSellTray()
    {
      sellSlotUi.Setup(inventory, indexInInventorySelected);
      priceText.text = "";
    }

    private void UpdateSellTray()
    {
      sellSlotUi.Setup(inventory, indexInInventorySelected);

      if (inventory.GetItemInSlot(indexInInventorySelected) != null)
      {
        priceText.text = (totalValueToBeExchanged).ToString();
      }
      else
      {
        priceText.text = "";
      }
    }
  }
}
