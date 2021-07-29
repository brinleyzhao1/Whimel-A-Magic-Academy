using Audio;
using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.UI.Inventories;
using Player;
using Player.Interaction;
using TMPro;
using UnityEngine;

namespace UI_Scripts.Shop
{
  /// <summary>
  ///sit on sell tray (UI)
  /// there should only exist one copy
  /// </summary>
  public class SellTray : MonoBehaviour
  {

    #region Singleton

    public static SellTray Instance { get; private set; }


    private void Awake()
    {
      if (Instance != null && Instance != this)
      {
        Destroy(this.gameObject);
      }
      else
      {
        Instance = this;
      }
    }

    #endregion


    // PRIVATE STATE
    [Tooltip("in child")] [SerializeField] private InventorySlotUi sellSlotUi; //in child
    [SerializeField] private TextMeshProUGUI priceText;

    private int indexInInventorySelected;
    private int amountInTransaction;
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

      Money.Instance.AddOrMinusMoney(totalValueToBeExchanged);
      Inventory.GetPlayerInventory().RemoveFromSlot(indexInInventorySelected, amountInTransaction);

      UpdateSellTray();

      AudioAssets.AudioSource.PlayOneShot(AudioAssets.Money);

      // if (Inventory.GetPlayerInventory().GetNumberInSlot(indexInInventorySelected) == 0)
      // {
      //   sellingTrayItemImage.enabled = false;
      //   GetComponent<Image>().color = Color.gray;
      //
      //   GetComponent<Button>().enabled = false;
      //   priceText.text = "";
      // }
    }

    public void ReceiveInfoAboutSelectedItemForSell(int index, int amount)
    {
      indexInInventorySelected = index;
      totalValueToBeExchanged = inventory.GetItemInSlot(index).sellingPrice * inventory.GetNumberInSlot(index);
      amountInTransaction = amount;
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
