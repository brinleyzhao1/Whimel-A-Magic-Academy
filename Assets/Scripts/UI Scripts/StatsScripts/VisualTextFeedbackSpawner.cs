using System.Collections;
using Audio;
using TMPro;
using UnityEngine;

namespace UI_Scripts.StatsScripts
{
  public class VisualTextFeedbackSpawner : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI visualTextItem;
    [SerializeField] private Color statRewardTextColor;
    [SerializeField] private Color skillRewardTextColor;


    public void SpawnStatsChangeVisualItem(string statName, int valueChange, int statOrSkill)
    {
      GetComponent<AudioSource>().PlayOneShot(AudioAssets.Scribble);

      TextMeshProUGUI newVisualItem = Instantiate(visualTextItem, transform);
      SetUpText(statName, valueChange, statOrSkill, newVisualItem);

      StartCoroutine(CloseMySelf(3));
    }

    private void SetUpText(string statName, int valueChange, int statOrSkill, TextMeshProUGUI newVisualItem)
    {
      if (statOrSkill == 0) //stat
      {
        newVisualItem.color = statRewardTextColor;
      }
      else if (statOrSkill == 1) //skill
      {
        newVisualItem.color = skillRewardTextColor;
      }

      newVisualItem.transform.position =
        newVisualItem.transform.position + Vector3.up * 170; //magic number ;(, used to position visual

      if (valueChange >= 0)
      {
        newVisualItem.GetComponent<TextMeshProUGUI>().text = statName + " +" + valueChange;
      }
      else
      {
        newVisualItem.GetComponent<TextMeshProUGUI>().text = statName + " -" + valueChange * -1;
      }
    }


    IEnumerator CloseMySelf(int seconds)
    {
      yield return new WaitForSeconds(seconds);

      foreach (Transform child in transform) {
        Destroy(child.gameObject);
      }

      gameObject.SetActive(false);
    }
  }
}
