﻿using System.Collections;
using Audio;
using TMPro;
using UnityEngine;

namespace UI_Scripts.StatsScripts
{
  public class VisualTextFeedbackSpawner : MonoBehaviour
  {
    [SerializeField] private GameObject visualTextItem;


    public void SpawnStatsChangeVisualItem(string statName, int valueChange)
    {
      GetComponent<AudioSource>().PlayOneShot(AudioAssets.Scribble);

      GameObject newVisualItem = Instantiate(visualTextItem, transform);
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

      StartCoroutine(CloseMySelf(3));
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
