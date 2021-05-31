// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.PlayerLoop;
// using UnityEngine.SceneManagement;
//
// namespace SceneManagement
// {
//
//   public class Portal : MonoBehaviour
//   {
//     enum DestinationIdentifier
//     {
//       A,B,C,D
//     }
//
//
//
//     [SerializeField] private int sceneToLoad = -1;
//     [SerializeField] private Transform spawnPoint;
//     [SerializeField] private DestinationIdentifier portalPairCode;
//
//     [SerializeField] private float fadeOutTime = 1f;
//     [SerializeField] private float fadeInTime = 0.5f;
//     [SerializeField] private float fadeWaitTime = 0.5f;
//
//
//     private void OnTriggerEnter(Collider other)
//     {
//
//       if (other.CompareTag("Player") )
//       {
//         StartCoroutine(Transition());
//         print("ok");
//       }
//     }
//
//
//     private IEnumerator Transition()
//     {
//       if (sceneToLoad < 0)
//       {
//         Debug.LogError("scene to load is not set");
//         yield break;
//       }
//       DontDestroyOnLoad(gameObject);
//
//       Fader fader = FindObjectOfType<Fader>();
//
//       yield return fader.FadeOut(fadeOutTime);
//
//       SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();
//       wrapper.Save();
//
//       yield return SceneManager.LoadSceneAsync(sceneToLoad);
//
//       wrapper.Load();
//
//       Portal otherPortal = GetOtherPortal();
//       UpdatePlayer(otherPortal);
//
//
//       wrapper.Save();
//       wrapper.Load();
//
//       yield return new WaitForSeconds(fadeWaitTime); // wait for cameras and other stuff to set up
//       yield return fader.FadeIn(fadeInTime);
//
//       Destroy(gameObject);
//     }
//
//     private void UpdatePlayer(Portal otherPortal)
//     {
//       GameObject player = GameObject.FindWithTag("Player");
//       player.transform.position = otherPortal.spawnPoint.position;
//       player.transform.rotation = otherPortal.spawnPoint.rotation;
//     }
//
//     private Portal GetOtherPortal()
//     {
//       foreach (Portal portal in FindObjectsOfType<Portal>())
//       {
//         if (portal == this) continue;
//         if (portal.portalPairCode != portalPairCode) continue;
//         return portal;
//       }
//
//       return null;
//     }
//   }
//
// }
