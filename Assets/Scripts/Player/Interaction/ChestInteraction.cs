using GameDev.tv_Assets.Scripts.Inventories;
using GameDevTV.Inventories;
using UI;
using UI_Scripts;
using UnityEngine;

namespace Player.Interaction
{
  public class ChestInteraction : Interactable
  {


    protected override void Interact()
    {
      //pass in items in this chest for ui to draw
      Inventory thisChestInventory = GetComponent<Inventory>();
      GameAssets.ChestPanel.GetComponentInChildren<ChestInventoryUi>().SetThisChestInventory(thisChestInventory);

      GameAssets.ChestPanel.SetActive(true);
    }
  }
}
