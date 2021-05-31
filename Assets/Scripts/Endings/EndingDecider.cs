using System;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Endings
{
  public class EndingDecider : MonoBehaviour
  {
    private EndingItem[] allEndings;
    private Dictionary<string, int> _stats;
    [SerializeField] private EndingItem defaultEnding;


    private void Start()
    {
      allEndings = Resources.LoadAll<EndingItem>("Endings");

      _stats = (Dictionary<string, int>)FindObjectOfType<PlayerStats>().CaptureState();

    }

    public EndingItem DecideEnding()
    {
      foreach (var ending in allEndings)
      {
        //todo this is not smart to repeat but ok for now
        string conditionName1 = ending.condition1.ToString();
        int currentStat1 = _stats[conditionName1];
        int goalStat1 = ending.minVal1;
        if (currentStat1 < goalStat1)
          break;

        string conditionName2 = ending.condition2.ToString();
        int currentStat2 = _stats[conditionName1];
        int goalStat2 = ending.minVal2;
        if (currentStat1 < goalStat1)
          break;

        string conditionName3 = ending.condition3.ToString();
        int currentStat3 = _stats[conditionName1];
        int goalStat3 = ending.minVal3;
        if (currentStat1 < goalStat1)
          break;

        string conditionName4 = ending.condition4.ToString();
        int currentStat4 = _stats[conditionName1];
        int goalStat4 = ending.minVal4;
        if (currentStat1 < goalStat1)
          break;

        return ending;
      }

      return defaultEnding;
    }
  }
}
