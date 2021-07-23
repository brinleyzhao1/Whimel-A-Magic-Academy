using System;
using Alchemy;
using Control;
using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.Utils.UI.Dragging;
using Player;
using Player.Interaction;
using UI_Scripts.Shop;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace GameDev.tv_Assets.Scripts.UI.Inventories
{
  public class InventorySlotUi : MonoBehaviour, IItemHolder, IDragContainer<InventoryItem>, ISelectHandler,
    IPointerClickHandler

  {
    // CONFIG DATA
    [SerializeField] InventoryItemIconInChild iconInChild = null; // own child
    [SerializeField] GameObject gray;

    // STATE
    public int index;
    InventoryItem thisItem; //todo: assumed all items are actionable in order to use them
    Inventory inventory;

    private bool canRightClickToSell;

    // PUBLIC
    public UnityEvent onRightClick;

    private void Update()
    {
      RightClickToSellAllInShopView();
    }


    public void Setup(Inventory inventory, int index)
    {
      this.inventory = inventory;
      this.index = index;
      thisItem = inventory.GetItemInSlot(index);


      if (index == -1) //this is an attempt to clear this slot
      {
        iconInChild.SetItem(null, 0);
      }
      else // else
      {
        iconInChild.SetItem(inventory.GetItemInSlot(index), inventory.GetNumberInSlot(index));
      }
    }

    public int MaxAcceptable(InventoryItem item)
    {
      if (inventory.HasSpaceFor(item))
      {
        return int.MaxValue;
      }

      return 0;
    }

    public void AddItems(InventoryItem item, int number)
    {
      inventory.AddItemToSlot(index, item, number);
    }

    public InventoryItem GetItem()
    {
      return inventory.GetItemInSlot(index);
    }

    public int GetNumber()
    {
      return inventory.GetNumberInSlot(index);
    }

    public void RemoveItems(int number)
    {
      inventory.RemoveFromSlot(index, number);
    }


    public void GrayOut()
    {
      //transform.Find("grayMask").gameObject.SetActive(true);
    }


    /// <summary>
    /// select for sell tray
    /// </summary>
    /// <param name="eventData"></param>
    public void OnSelect(BaseEventData eventData)
    {
      //tell sell tray what thisItem and how many
      if (SellTray.Instance.gameObject.activeSelf)
      {
        SellTray.Instance.ReceiveInfoAboutSelectedItemForSell(index);
      }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
      if (!GameAssets.ShopPanel.activeSelf) return;
      if (!inventory.GetItemInSlot(index)) return;
      CursorChanger.Instance.SetMovingCursor(CursorType.Sell);
      canRightClickToSell = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      if (!GameAssets.ShopPanel.activeSelf) return;
      if (!inventory.GetItemInSlot(index)) return;
      CursorChanger.Instance.SetMovingCursor(CursorType.None);
      canRightClickToSell = false;
    }

    private void RightClickToSellAllInShopView()
    {
      if (canRightClickToSell && Input.GetMouseButtonDown(1))
      {
        //sell all
        int amount = inventory.GetNumberInSlot(index);
        int totalValueToBeExchanged = inventory.GetItemInSlot(index).sellingPrice * amount;
        Money.Instance.AddOrMinusMoney(totalValueToBeExchanged);
        Inventory.GetPlayerInventory().RemoveFromSlot(index, amount);
      }
    }

    /// <summary>
    /// parallel to ActionStore's ActionStoreUse
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
      if (eventData.button == PointerEventData.InputButton.Right)
      {

        //use that item
        var thisIsAnActionRecipe = (ActionScriptableItem) thisItem;

        thisIsAnActionRecipe.Use(GameObject.FindWithTag("Player"));

        if (thisIsAnActionRecipe.IsConsumable())
        {
          inventory.RemoveFromSlot(this.index, 1);
        }

        //can only consume recipe once
        if (thisItem.GetType() == typeof(PotionRecipeScriptableObject))
        {
          var thisIsAPotionRecipe = (PotionRecipeScriptableObject) thisItem;
          if (!Alchemy.Alchemy.Instance.AlreadyKnownThisRecipe(thisIsAPotionRecipe))
          {
            Alchemy.Alchemy.Instance.AddNewPotionRecipe(thisIsAPotionRecipe);
            inventory.RemoveFromSlot(this.index, 1);
          }

          StoreUpdated?.Invoke();
        }

      }
    }

    /// <summary>
    /// Broadcasts when the items in the slots are added/removed.
    /// </summary>
    public event Action StoreUpdated;
  }
}
