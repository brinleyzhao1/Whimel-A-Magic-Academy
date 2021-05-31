using GameDev.tv_Assets.Scripts.Saving;
using GameDevTV.Saving;
using UnityEngine;

namespace Player.Movement
{
  public class CharacterMovement : MonoBehaviour, ISaveable
  {
    CharacterController _characterController;
    [SerializeField] private float _moveSpeed = 3.5f;
    [SerializeField] private float _gravity = 9.8f;
    private static readonly int ForwardSpeed = Animator.StringToHash("forwardSpeed");

    void Awake() => _characterController = GetComponent<CharacterController>();


    // Update is called once per frame
    void Update()
    {
      CalculateMovement();
    }


    private void CalculateMovement()
    {
      Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
      Vector3 velocity = direction * _moveSpeed;
      UpdateAnimator(velocity);

      velocity.y -= _gravity;
      velocity = transform.TransformDirection(velocity);
      _characterController.Move(velocity * Time.deltaTime);
    }

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

      data.position = new SerializableVector3(transform.position);
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
