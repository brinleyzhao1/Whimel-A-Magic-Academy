using Audio;
using GameDev.tv_Assets.Scripts.Inventories;
using Player;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace UI_Scripts.Shop
{
  public class ShopItemEntryUi : MonoBehaviour
  {
    // private string itemId;
    private InventoryItem thisItem;

    [Header("from children")] [SerializeField]
    private Image entryImage;

    [SerializeField] private TMP_Text entryNameText;
    [SerializeField] private TMP_Text entryPriceText;


    public void SetUp(InventoryItem item)
    {
      entryImage.sprite = item.GetIcon();
      entryNameText.text = item.GetDisplayName();
      entryPriceText.text = item.buyingPrice.ToString();

      thisItem = item;
    }

    public void Buy()
    {
      var player = GameObject.FindGameObjectWithTag("Player");
      var inventory = player.GetComponent<Inventory>();

      var money = player.GetComponent<Money>();
      int moneyHave = money.money;

      if (moneyHave >= thisItem.buyingPrice)
      {
        inventory.AddToFirstEmptySlot(thisItem, 1);
        money.AddOrMinusMoney(-thisItem.buyingPrice);
        AudioAssets.AudioSource.PlayOneShot(AudioAssets.Money);
      }
      else
      {
        AudioAssets.AudioSource.PlayOneShot(AudioAssets.Error);
      }
    }
  }
}
