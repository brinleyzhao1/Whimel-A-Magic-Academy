
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
  public class StatsTabUi : MonoBehaviour
  {

    [SerializeField] private GameObject statsItemPrefab;
    [SerializeField] private string[] statsDescriptions;


    public void UpdateStatsUi(Dictionary<string, int> stats)
    {
      foreach (Transform child in transform) {
        Destroy(child.gameObject);
      }

      int statsNum = 0;
      foreach (var statEntry in stats)
      {
        GameObject newEntry = Instantiate(statsItemPrefab, transform);
        newEntry.transform.GetChild(0).GetComponent<TMP_Text>().text = statEntry.Key;
        newEntry.transform.GetChild(1).GetComponent<TMP_Text>().text = statEntry.Value.ToString();


        // newEntry.transform.GetComponent<StatsItemTooltipSpawner>().description = statsDescriptions[statsNum++];

      }
    }
  }
}
