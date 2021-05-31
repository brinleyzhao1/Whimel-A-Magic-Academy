using UnityEngine;

public class MoveWithForceUseTransformRotationClampVelocity : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    [SerializeField] private float _movementForce = 10f;
    [SerializeField] private double _maximumVelocity = 10f;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.magnitude >= _maximumVelocity)
            return;
        
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