using System.Collections.Generic;
using Control;
using TMPro;
using UI_Scripts;
using UnityEngine;

namespace UI
{
  public class ResultPanelUi :  UiPanelGeneric
  {
    //only need to know the 3+1 number

    public void Setup(Dictionary<string, int> statsChangeDictionary)
    {
      Transform board = transform.GetChild(0);
      int i = 0;
      foreach (var stat in statsChangeDictionary)
      {
        Transform entry = board.GetChild(i);
        entry.GetChild(0).GetComponent<TMP_Text>().text = stat.Key;
        entry.GetChild(1).GetComponent<TMP_Text>().text = "+" + stat.Value.ToString();
        i++;
      }

      // for energy
       Transform energyEntry = board.GetChild(3);
       energyEntry.GetChild(0).GetComponent<TMP_Text>().text = "energy";
       energyEntry.GetChild(1).GetComponent<TMP_Text>().text = "-5"; //todo customize energy for a class

    }

  }
}
