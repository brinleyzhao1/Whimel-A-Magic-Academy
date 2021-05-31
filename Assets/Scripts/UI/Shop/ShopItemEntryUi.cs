using GameDev.tv_Assets.Scripts.Inventories;
using GameDevTV.Inventories;
using Microsoft.Unity.VisualStudio.Editor;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace UI
{
  public class ShopItemEntryUi : MonoBehaviour
  {
    private string itemId;
    private InventoryItem thisItem;



    public void SetUp(InventoryItem item)
    {
      transform.GetChild(0).GetComponent<Image>().sprite = item.GetIcon();
      transform.GetChild(1).GetComponent<TMP_Text>().text = item.name;
      transform.GetChild(3).GetComponent<TMP_Text>().text = item.buyingPrice.ToString();

      thisItem = item;

    }

    public void Buy()
    {
      var player = GameObject.FindGameObjectWithTag("Player");
      var inventory = player.GetComponent<Inventory>();
      inventory.AddToFirstEmptySlot(thisItem, 1);
      player.GetComponent<Money>().AddOrMinusMoney(-thisItem.buyingPrice);
    }


  }
}
