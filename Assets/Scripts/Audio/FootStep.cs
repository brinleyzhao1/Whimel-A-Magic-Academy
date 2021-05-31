using System;
using UnityEngine;

namespace Audio
{
  public class FootStep : MonoBehaviour
  {
    private AudioSource myAudioSource;


    private void Start()
    {
      myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0)
      {
        // myAudioSource.loop();
        myAudioSource.enabled = true;
      }
      else
      {
        myAudioSource.enabled = false;
        // myAudioSource.Stop();
      }
    }
  }
}
