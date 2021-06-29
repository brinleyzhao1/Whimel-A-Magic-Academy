using TMPro;
using UnityEngine;

namespace UI.StatsScripts
{
  public class VisualTextFeedbackSpawner : MonoBehaviour
  {
    [SerializeField] private GameObject visualTextItem;

    public void SpawnStatsChangeVisualItem(string statName, int valueChange)
    {
      GameObject newVisualItem = Instantiate(visualTextItem, transform);
      newVisualItem.transform.position = newVisualItem.transform.position + Vector3.up*170; //magic number ;(, used to position visual

      if (valueChange >= 0)
      {
        newVisualItem.GetComponent<TextMeshProUGUI>().text = statName + " + " + valueChange;
      }
      else
      {
        newVisualItem.GetComponent<TextMeshProUGUI>().text = statName + " - " + valueChange*-1;
      }

    }
  }
}
