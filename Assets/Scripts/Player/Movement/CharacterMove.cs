using GameDev.tv_Assets.Scripts.Saving;
using UnityEngine;

namespace Player.Movement
{
  public class CharacterMove : MonoBehaviour, ISaveable
  {
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpSpeed = 0.5f;
    [SerializeField] private float _gravity = 2f;

    CharacterController _characterController;
    private Vector3 _moveDirection;
    private static readonly int ForwardSpeed = Animator.StringToHash("forwardSpeed");

    void Awake() => _characterController = GetComponent<CharacterController>();
    void FixedUpdate()
    {
      float horizontal = Input.GetAxis("Horizontal");
      float vertical = Input.GetAxis("Vertical");

      Vector3 inputDirection = new Vector3(horizontal, 0, vertical);
      Vector3 transformDirection = transform.TransformDirection(inputDirection);

      Vector3 flatMovement = _moveSpeed * Time.deltaTime * transformDirection;

      _moveDirection = new Vector3(flatMovement.x, _moveDirection.y , flatMovement.z);

      if (PlayerJumped)
        _moveDirection.y = _jumpSpeed;
      else if (_characterController.isGrounded)
        _moveDirection.y = 0f;
      else
        _moveDirection.y -= _gravity * Time.deltaTime;

      _characterController.Move(_moveDirection);
    }

    private bool PlayerJumped => _characterController.isGrounded && Input.GetKey(KeyCode.Space);


    private void UpdateAnimator(Vector3 velocity)
    {
      float speed = velocity.z;
      GetComponent<Animator>().SetFloat(ForwardSpeed, speed);
    }



    [System.Serializable]
    struct MoverSaveData
    {
      public SerializableVector3 position;
      public SerializableVector3 rotation;
    }

    public object CaptureState()
    {
      MoverSaveData data = new MoverSaveData();

      data.position =  new SerializableVector3(transform.position);
      data.rotation = new SerializableVector3(transform.eulerAngles);
      return data;
    }

    public void RestoreState(object state)
    {
      MoverSaveData data = (MoverSaveData) state;

      // navMeshAgent.enabled = false;
      _characterController.enabled = false;
      transform.position = data.position.ToVector();
      transform.eulerAngles = data.rotation.ToVector();
      _characterController.enabled = true;
      // navMeshAgent.enabled = true;
      // GetComponent<ActionScheduler>().CancelCurrentAction();
    }
  }
}

