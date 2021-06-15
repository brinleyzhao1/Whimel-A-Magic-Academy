using System;
using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.Utils.UI.Dragging;
using UnityEngine;

namespace GameDev.tv_Assets.Scripts.UI.Inventories
{
  public class TrashCanUi : MonoBehaviour, IDragContainer<InventoryItem>
  {
    public int MaxAcceptable(InventoryItem item)
    {
      return Int32.MaxValue;
    }

    public void AddItems(InventoryItem item, int number)
    {
      //equivenlent to deleting item
      print("threw away " + item.name );

    }

    public InventoryItem GetItem()
    {
      return null;
    }

    public int GetNumber()
    {
      throw new System.NotImplementedException();
    }

    public void RemoveItems(int number)
    {
      throw new System.NotImplementedException();
    }
  }
}
