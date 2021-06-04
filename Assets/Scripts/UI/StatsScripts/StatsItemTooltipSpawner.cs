using GameDev.tv_Assets.Scripts.UI.Inventories;
using GameDev.tv_Assets.Scripts.Utils.UI.Tooltips;
using GameDevTV.UI.Inventories;
using UnityEngine;

namespace UI
{
  public class StatsItemTooltipSpawner :  TooltipSpawner
  {
    public string description;



    public override void UpdateTooltip(GameObject tooltip)
    {
      var itemTooltip = tooltip.GetComponent<ItemTooltip>();
      if (!itemTooltip) return;
      //
      // var item = GetComponent<IItemHolder>().GetItem();

      itemTooltip.SetupOnlyText(description);
    }

    public override bool CanCreateTooltip()
    {
      // var item = GetComponent<IItemHolder>().GetItem();
      // if (!item) return false;

      return true;
    }
  }
}
