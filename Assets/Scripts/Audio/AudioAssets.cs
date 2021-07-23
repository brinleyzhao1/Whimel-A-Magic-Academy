using UnityEngine;

namespace Audio
{
  public class AudioAssets : MonoBehaviour
  {
    [Header("Audio Clip")]
    [SerializeField] public AudioClip setScribble;
    public static AudioClip Scribble;

    [SerializeField] public AudioClip setRemove;
    public static AudioClip Remove;

    [Header("Audio Source")]
    [SerializeField] public AudioSource setUiPaperSound;
    public static AudioSource AudioSource;

    private void Awake()
    {
      Remove = setRemove;
      AudioSource = setUiPaperSound;
      Scribble = setScribble;

    }
  }
}
