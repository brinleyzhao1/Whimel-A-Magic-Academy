using UnityEngine;

namespace Audio
{
  public class ButtonPaperSound : MonoBehaviour
  {
    private AudioSource myAudioSource;


    private void Start()
    {
      myAudioSource = GetComponent<AudioSource>();
    }

    public void PlayPaperSound() // for buttons
    {
      myAudioSource.Play();
    }
  }
}
