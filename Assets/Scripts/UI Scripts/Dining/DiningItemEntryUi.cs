using GameDev.tv_Assets.Scripts.Inventories;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts.Dining
{
  /// <summary>
  /// parallel to ShopItemEntryUi
  /// sit on each DiningItemUi
  /// todo abstraction
  /// </summary>
  public class DiningItemEntryUi : MonoBehaviour
  {
    // private string itemId;
    private ActionScriptableItem thisItem;

    [Header("from children")] [SerializeField]
    private Image entryImage;

    [SerializeField] private TMP_Text entryNameText;


    public void SetUp(ActionScriptableItem item)
    {
      entryImage.sprite = item.GetIcon();
      entryNameText.text = item.GetDisplayName();

      thisItem = item;
    }

    public void ButtonEat()
    {
      var player = GameObject.FindGameObjectWithTag("Player");
      var inventory = player.GetComponent<Inventory>();
      inventory.AddToFirstEmptySlot(thisItem, 1);
      player.GetComponent<Money>().AddOrMinusMoney(-thisItem.buyingPrice);
    }
  }
}
