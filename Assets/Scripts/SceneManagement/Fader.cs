using System;
using System.Collections;
using UnityEngine;

namespace SceneManagement
{
  public class Fader : MonoBehaviour
  {
    private CanvasGroup _canvasGroup;


    private void Awake()
    {
      _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeOutImmediate()
    {
      _canvasGroup.alpha = 1;
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.F))
      {
        FadeOutImmediate();
      }
    }


    public IEnumerator FadeOut(float time)
    {

      while (_canvasGroup.alpha < 1)
      {
        _canvasGroup.alpha += Time.deltaTime / time;
        if (Math.Abs(Time.timeScale) < 0.2) //when pause menu wants to fade out but time is paused
        {
          _canvasGroup.alpha = 1;
        }

        yield return null;
      }
    }

    public IEnumerator FadeIn(float time)
    {
      while (_canvasGroup.alpha > 0)
      {
        _canvasGroup.alpha -= Time.deltaTime / time;
        yield return null;
      }
    }
  }
}
