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

     IEnumerator FadeOutIn()
    {
      yield return FadeOut(3f);
      yield return FadeIn(1f);
    }

    public IEnumerator FadeOut(float time)
    {
      while (_canvasGroup.alpha < 1)
      {
        _canvasGroup.alpha += Time.deltaTime / time;
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
