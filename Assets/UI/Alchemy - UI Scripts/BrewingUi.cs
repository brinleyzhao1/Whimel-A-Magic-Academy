using Alchemy;
using TMPro;
using UnityEngine;

namespace UI
{
  public class BrewingUi : MonoBehaviour
  {

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    //when selected, update visual
    public void UpdateDisplayedInfo(PotionRecipeScriptableObject recipe)
    {
      titleText.text = recipe.GetDisplayName();
      descriptionText.text = recipe.GetDescription();

      //update ingredients list

    }



    public void CheckIfHaveAllIngredients()
    {

    }

    public void Brew()
    {

    }
  }
}
