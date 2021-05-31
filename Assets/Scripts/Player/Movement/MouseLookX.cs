using UnityEngine;

namespace Player.Movement
{
  public class MouseLookX : MonoBehaviour
  {
    [SerializeField] private float sensitivity = 1f;
    private bool _followMouse = true;
    private GameObject _lookY;

    private void Start()
    {
      // Cursor.lockState = CursorLockMode.Locked;
      _lookY = GameObject.Find("MouseLookY");

    }

    // Update is called once per frame
    void Update()
    {
      if (_followMouse)
      {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += mouseX * sensitivity;
        transform.localEulerAngles = newRotation;
      }
    }

    public void StopMouseLook()
    {
      _followMouse = false;
      _lookY.SetActive(false);
    }
    public void StartMouseLook()
    {
      _followMouse = true;
      _lookY.SetActive(true);
    }
  }
}
