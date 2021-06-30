using Control;
using SceneManagement;
using UI_Scripts;
using UnityEngine;

namespace Player.Movement
{
  public class DoorSameScene : Interactable
  {
    [SerializeField]
    float interactiveDistance = 2f;

    [SerializeField] private CursorType cursorType = CursorType.Door;

    protected override void Interact()
    {
      GameObject player = GameObject.FindWithTag("Player");
      CharacterController characterController = player.GetComponent<CharacterController>();
      SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();

      characterController.enabled = false;
      Vector3 forwardDirection = new Vector3(0,0,interactiveDistance+0.1f);
      player.transform.position += player.transform.TransformDirection(forwardDirection) ;
      // player.transform.position += player.transform.TransformDirection(player.transform.forward * interactiveDistance) ;
      characterController.enabled = true;
      wrapper.Save();
    }

    // private void OnMouseOver()
    // {
    //   if (Input.GetMouseButtonDown(1))
    //   {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     RaycastHit hit;
    //
    //     if (Physics.Raycast(ray, out hit, interactiveDistance))
    //     {
    //       GameObject player = GameObject.FindWithTag("Player");
    //       CharacterController characterController = player.GetComponent<CharacterController>();
    //       SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();
    //
    //       characterController.enabled = false;
    //       Vector3 forwardDirection = new Vector3(0,0,interactiveDistance);
    //       player.transform.position += player.transform.TransformDirection(forwardDirection) ;
    //       // player.transform.position += player.transform.TransformDirection(player.transform.forward * interactiveDistance) ;
    //       characterController.enabled = true;
    //       wrapper.Save();
    //
    //     }
      // }
    // }
  }
}
