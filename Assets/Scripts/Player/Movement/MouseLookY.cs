using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookY : MonoBehaviour
{
  [SerializeField] private float sensitivity = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      float _mouseX = Input.GetAxis("Mouse Y");
      Vector3 newRotation = transform.localEulerAngles;
      newRotation.x -= _mouseX * sensitivity;
      transform.localEulerAngles = newRotation;


    }
}
