using System;
using System.Collections.Generic;
using Player;
using Stats;
using UnityEngine;

namespace Endings
{
  public class EndingDecider : MonoBehaviour
  {
    private EndingItem[] allEndings;
    private Dictionary<StatsType, int> _currentPlayerStats;
    [SerializeField] private EndingItem defaultEnding; //note the default ending can't be in the same folder as the other endings
    [SerializeField] private EndingDisplayer endingDisplayer;

    private void Start()
    {
      allEndings = Resources.LoadAll<EndingItem>("EndingItems");
      // print("there are a total of endings: " + allEndings.Length);

      _currentPlayerStats = (Dictionary<StatsType, int>)PlayerStats.Instance.CaptureState();

    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.O))//testing purpose
      {
        GetEnding();
      }
    }

    public void GetEnding()
    {
      EndingItem finalEnding = DecideEnding();
      CallDisplayEnding(finalEnding);
    }


    private EndingItem DecideEnding()
    {
      foreach (var ending in allEndings)
      {
        //todo this is not smart to repeat but ok for now
        StatsType conditionName1 = ending.condition1;
        int currentStat1 = _currentPlayerStats[conditionName1];
        int goalStat1 = ending.minVal1;
        if (currentStat1 < goalStat1)
          break;

        StatsType conditionName2 = ending.condition2;
        int currentStat2 = _currentPlayerStats[conditionName2];
        int goalStat2 = ending.minVal2;
        if (currentStat2 < goalStat2)
          break;

        StatsType conditionName3 = ending.condition3;
        int currentStat3 = _currentPlayerStats[conditionName3];
        int goalStat3 = ending.minVal3;
        if (currentStat3 < goalStat3)
          break;

        StatsType conditionName4 = ending.condition4;
        int currentStat4 = _currentPlayerStats[conditionName4];
        int goalStat4 = ending.minVal4;
        if (currentStat4 < goalStat4)
          break;

        return ending;
      }

      return defaultEnding;
    }

    private void CallDisplayEnding(EndingItem ending)
    {
      // EndingDisplayer endingDisplayer = FindObjectOfType<EndingDisplayer>();
      // print(endingDisplayer.name);
      endingDisplayer.gameObject.SetActive(true);

      endingDisplayer.DisplayEnding(ending);
    }
  }
}
