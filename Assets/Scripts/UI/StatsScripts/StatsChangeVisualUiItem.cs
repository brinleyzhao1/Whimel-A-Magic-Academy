using System;
using TMPro;
using UnityEngine;

namespace UI.StatsScripts
{
  public class StatsChangeVisualUiItem : MonoBehaviour
  {
    private void Update()
    {
      transform.position = transform.position + Vector3.up; //fly upward

      if (transform.position.y > 600)
      {
        Destroy(gameObject);
      }
    }
  }
}
