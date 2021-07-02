using UnityEngine;

namespace Audio
{
  public class AudioAssets : MonoBehaviour
  {
    [Header("Core")]
    [SerializeField] public AudioClip setScribble;
    public static AudioClip Scribble;

    private void Awake()
    {
      Scribble = setScribble;

    }
  }
}
