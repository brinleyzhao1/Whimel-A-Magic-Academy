using UnityEngine;

namespace Audio
{
  public class AudioAssets : MonoBehaviour
  {
    [Header("Audio Clip")]

    [SerializeField] public AudioClip setPaper;
    public static AudioClip Paper;

    [SerializeField] public AudioClip setScribble;
    public static AudioClip Scribble;

    [SerializeField] public AudioClip setError;
    public static AudioClip Error;

    [SerializeField] public AudioClip setRemove;
    public static AudioClip Remove;

    [SerializeField] public AudioClip setBuyAndSell;
    public static AudioClip Money;

    [Header("Audio Source")]
    [SerializeField] public AudioSource setUiPaperSound;
    public static AudioSource AudioSource;

    private void Awake()
    {
      Money = setBuyAndSell;
      Paper = setPaper;
      Error = setError;
      Remove = setRemove;
      AudioSource = setUiPaperSound;
      Scribble = setScribble;

    }
  }
}
