using System;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 3f;


    private Camera mainCamera;

    private void Start()
    {
      mainCamera = Camera.main;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        transform.Rotate(horizontal * _turnSpeed * Vector3.up, Space.World);

        float vertical = Input.GetAxis("Mouse Y");
        mainCamera.transform.Rotate(vertical * _turnSpeed * Vector3.left, Space.Self);

    }
}
