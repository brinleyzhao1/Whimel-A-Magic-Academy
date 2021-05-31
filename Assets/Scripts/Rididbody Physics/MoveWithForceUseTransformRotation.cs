using UnityEngine;

public class MoveWithForceUseTransformRotation : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    [SerializeField] private float _movementForce = 10f;
    
    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            _rigidbody.AddForce(_movementForce * transform.forward);
        
        if (Input.GetKey(KeyCode.S))
            _rigidbody.AddForce(_movementForce * -transform.forward); // -forward gives us back

        if (Input.GetKey(KeyCode.D))
            _rigidbody.AddForce(_movementForce * transform.right);
        
        if (Input.GetKey(KeyCode.A))
            _rigidbody.AddForce(_movementForce * -transform.right); // -right gives us left
    }
}