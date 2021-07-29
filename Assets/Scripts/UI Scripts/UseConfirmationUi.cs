using System;
using Alchemy;
using Control;
using GameDev.tv_Assets.Scripts.Inventories;
using Player;
using Player.Interaction;
using TMPro;
using UnityEngine;

namespace UI_Scripts
{
  public class UseConfirmationUi : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI text;

    private ActionScriptableItem thisItem;
    private int thisIndex;
    private int mode; // 0 for inventory, 1 for action bar, 2 for others like dining
    private ActionStore actionStore;

    private void Start()
    {
      actionStore = GameObject.FindGameObjectWithTag("Player").GetComponent<ActionStore>();
    }

    public void Setup(ActionScriptableItem item, int inventoryOrActionBar, int index)
    {
      thisItem = item;
      thisIndex = index;
      text.text = "Use " + item.GetDisplayName() + "?";
      mode = inventoryOrActionBar;
    }

    public void ButtonConfirmUse()
    {
      //remove 1
      if (thisItem.IsConsumable())
      {
        RemoveItemFromPlace();
      }


      if (thisItem.GetType() == typeof(PotionRecipeObject))
      {
        var thisIsAPotionRecipe = (PotionRecipeObject) thisItem;
        if (!Alchemy.Alchemy.Instance.AlreadyKnownThisRecipe(thisIsAPotionRecipe))
        {
          Alchemy.Alchemy.Instance.AddNewPotionRecipe(thisIsAPotionRecipe);
          RemoveItemFromPlace();
        }
        // StoreUpdated?.Invoke();
        else
        {
          //not consume this recipe
        }


        PlayerEnergy.Instance.UpdateEnergyByValue(thisItem.energyChange);

        CursorChanger.Instance.OneLessUiOut();


        gameObject.SetActive(false);
      }
    }

    private void RemoveItemFromPlace()
    {
      if (mode == 0) // inventory
      {
        GameAssets.PlayerInventory.RemoveFromSlot(thisIndex, 1);
      }
      else if (mode == 1) //action bar
      {
        actionStore.RemoveItems(thisIndex, 1);
      }
    }
  }
}
