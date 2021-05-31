using SceneManagement;
using UnityEngine;

namespace Player.Movement
{
  public class DoorSameScene : MonoBehaviour
  {
    [SerializeField]
    float interactiveDistance = 3f;

    private void OnMouseOver()
    {
      if (Input.GetMouseButtonDown(1))
      {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactiveDistance))
        {
          GameObject player = GameObject.FindWithTag("Player");
          CharacterController characterController = player.GetComponent<CharacterController>();
          SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();

          characterController.enabled = false;
          Vector3 forwardDirection = new Vector3(0,0,interactiveDistance);
          player.transform.position += player.transform.TransformDirection(forwardDirection) ;
          // player.transform.position += player.transform.TransformDirection(player.transform.forward * interactiveDistance) ;
          characterController.enabled = true;
          wrapper.Save();

        }
      }
    }
  }
}
