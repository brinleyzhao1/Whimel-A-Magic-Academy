using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.UI.Inventories;
using Player.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace UI
{
  public class IngredientSlotUi : MonoBehaviour
  {
    // CONFIG DATA
    [SerializeField] Image iconImage = null;
    [SerializeField] TextMeshProUGUI number = null;

    public void UpdateIcon(ActionScriptableItem ingredient, int quantityRequired)
    {
      //icon image
      SetUpImage(ingredient);

      //set up text
      SetUpText(ingredient, quantityRequired);
    }

    private void SetUpImage(ActionScriptableItem ingredient)
    {
      if (ingredient == null)
      {
        iconImage.enabled = false;
      }
      else
      {
        iconImage.enabled = true;

        iconImage.sprite = ingredient.GetIcon();
      }
    }

    private void SetUpText(ActionScriptableItem ingredient, int quantityRequired)
    {
      int quantityHave = GameAssets.PlayerInventory.TotalAmountHave(ingredient);
      number.text = quantityRequired + "/" + quantityHave;

      if (quantityRequired > quantityHave)
      {
        number.color = Color.red;
      }
      else
      {
        number.color = Color.white;
      }

      if (quantityRequired == 0)
      {
        number.text = "";
      }
    }
  }
}
