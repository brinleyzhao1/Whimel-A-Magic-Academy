using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.Utils.UI.Dragging;
using GameDevTV.UI.Inventories;
using UnityEngine;
using UnityEngine.UI;

namespace GameDev.tv_Assets.Scripts.UI.Inventories
{
  /// <summary>
  /// The UI slot for the player action bar.
  /// </summary>
  public class ActionSlotUi : MonoBehaviour, IItemHolder, IDragContainer<InventoryItem>
  {
    // CONFIG DATA
    [SerializeField] InventoryItemIconInChild iconInChild = null;
    [SerializeField] int index = 0;
    [SerializeField] private Color selectedColor;

    // CACHE
    ActionStore actionStore;

    // LIFECYCLE METHODS
    private void Awake()
    {
      actionStore = GameObject.FindGameObjectWithTag("Player").GetComponent<ActionStore>();
      actionStore.StoreUpdated += UpdateIcon;
      UpdateIcon(); //update once in the beginning
    }

    // PUBLIC

    public void AddItems(InventoryItem item, int number)
    {
      actionStore.AddAction(item, index, number);
    }

    public InventoryItem GetItem()
    {
      return actionStore.GetAction(index);
    }

    public int GetNumber()
    {
      return actionStore.GetNumber(index);
    }

    public int MaxAcceptable(InventoryItem item)
    {
      return actionStore.MaxAcceptable(item, index);
    }

    public void RemoveItems(int number)
    {
      actionStore.RemoveItems(index, number);
    }

    private bool IsSelected()
    {
      return index == actionStore.currentIndexSelected;
    }

    // PRIVATE

    void UpdateIcon()
    {
      iconInChild.SetItem(GetItem(), GetNumber());

      //if is selected, highlight
      HighlightIfSelected();
    }

    private void HighlightIfSelected()
    {
      var slotImage = GetComponent<Image>();

      if (IsSelected())
      {
        // slotImage.color = Color.green;
        slotImage.color = selectedColor;
      }
      else
      {
        slotImage.color = Color.white;
      }
    }
  }
}
