using GameDev.tv_Assets.Scripts.Inventories;
using GameDevTV.Inventories;
using UI;
using UnityEngine;

namespace Player.Interaction
{
  public class ChestInteraction : TriggerUi
  {


    protected override void WhenTriggered()
    {
      //pass in items in this chest for ui to draw
      Inventory thisChestInventory = GetComponent<Inventory>();
      GameAssets.ChestPanel.GetComponentInChildren<ChestInventoryUi>().SetThisChestInventory(thisChestInventory);

      GameAssets.ChestPanel.SetActive(true);
    }
  }
}
