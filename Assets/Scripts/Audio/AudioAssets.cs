using UnityEngine;

namespace Audio
{
  public class AudioAssets : MonoBehaviour
  {
    [Header("Audio Clip")]
    [SerializeField] public AudioClip setScribble;
    public static AudioClip Scribble;

    [Header("Audio Source")]
    [SerializeField] public AudioSource setUiPaperSound;
    public static AudioSource UiPaperSound;

    private void Awake()
    {

      UiPaperSound = setUiPaperSound;
      Scribble = setScribble;

    }
  }
}
