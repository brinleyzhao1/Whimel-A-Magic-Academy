using UnityEngine;

public class PlayerExample : Singleton<PlayerExample>
{
  public float horizontalSpeed = 100;
  public float movementSpeed = 5;

  private void Update()
  {
    //Cheap movement
    float forwardMovement = Input.GetAxis("VerticalLS");
    float horizontalMovement = Input.GetAxis("HorizontalLS");
    transform.Translate(((-Vector3.forward * forwardMovement) + (Vector3.right * horizontalMovement)) * movementSpeed * Time.deltaTime);

    float desiredRotation = Input.GetAxis("HorizontalRS");
    transform.Rotate(Vector3.up, desiredRotation * horizontalSpeed * Time.deltaTime);
  }
}
