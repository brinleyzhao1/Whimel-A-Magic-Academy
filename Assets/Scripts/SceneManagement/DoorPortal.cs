using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
  public class DoorPortal : MonoBehaviour
  {
    enum DestinationIdentifier
    {
      A,
      B,
      C,
      D,
      E,
      F,
      G,
      H,
      I,
      J,
      K,
      L,
      M,
      N,
      O,
      P
    }


    // [SerializeField] private int sceneToLoad = -1;
    [SerializeField] private string sceneToLoad = null;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private DestinationIdentifier portalPairCode;

    [SerializeField] private float fadeOutTime = 0.1f;
    [SerializeField] private float fadeInTime = 0.1f;
    [SerializeField] private float fadeWaitTime = 0.5f;


    // private void OnTriggerEnter(Collider other)
    // {
    //   if (other.tag == "Player")
    //   {
    //     StartCoroutine(Transition());
    //   }
    // }


    private void OnMouseOver()
    {
      if (Input.GetMouseButtonDown(1))
      {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10))
        {

          StartCoroutine(Transition());
        }
      }
    }

    private IEnumerator Transition()
    {
      if (sceneToLoad == null)
      {
        Debug.LogError("scene to load is not set");
        yield break;
      }

      DontDestroyOnLoad(gameObject);

      Fader fader = FindObjectOfType<Fader>();

      yield return fader.FadeOut(fadeOutTime);

      SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();
      wrapper.Save();

      yield return SceneManager.LoadSceneAsync(sceneToLoad);

      wrapper.Load();

      DoorPortal otherPortal = GetOtherPortal();
      UpdatePlayer(otherPortal);


      wrapper.Save();
      wrapper.Load();

      yield return new WaitForSeconds(fadeWaitTime); // wait for cameras and other stuff to set up
      yield return fader.FadeIn(fadeInTime);

      Destroy(gameObject);
    }

    private void UpdatePlayer(DoorPortal otherPortal)
    {
      GameObject player = GameObject.FindWithTag("Player");
      player.transform.position = otherPortal.spawnPoint.position;
      player.transform.rotation = otherPortal.spawnPoint.rotation;
    }

    private DoorPortal GetOtherPortal()
    {
      foreach (DoorPortal portal in FindObjectsOfType<DoorPortal>())
      {
        if (portal == this) continue;
        if (portal.portalPairCode != portalPairCode) continue;
        return portal;
      }

      Debug.LogError("no matching door found");
      return null;
    }
  }
}
