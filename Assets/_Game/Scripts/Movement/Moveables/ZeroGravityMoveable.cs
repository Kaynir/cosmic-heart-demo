using UnityEngine;

namespace CosmicHeart.Movement.Moveables
{
    [RequireComponent(typeof(Rigidbody))]
    public class ZeroGravityMoveable : MonoBehaviour, IMoveable
    {
        [Header("Thrust Settings:")]
        [SerializeField, Min(0f)] private float thrustSpeed = 25f;
        [SerializeField] private ForceMode thrustForceMode = ForceMode.Acceleration;

        [Header("Torque Settings:")]
        [SerializeField, Min(0f)] private float pitchSpeed = 5f;
        [SerializeField, Min(0f)] private float yawSpeed = 5f;
        [SerializeField, Min(0f)] private float rollSpeed = 5f;
        [SerializeField] private ForceMode torqueForceMode = ForceMode.Acceleration;

        public float MoveSpeed
        {
            get => thrustSpeed;
            set => thrustSpeed = Mathf.Max(0f, value);
        }

        private Rigidbody body;

        private Vector3 thrust;
        private Vector3 torque;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
            body.useGravity = false;
            ResetVelocity();
        }

        private void FixedUpdate()
        {
            body.AddRelativeForce(thrust, thrustForceMode);
            body.AddRelativeTorque(torque, torqueForceMode);
        }

        private void OnDisable() => ResetVelocity();

        public void SetLookDirection(Vector3 lookDirection)
        {
            torque.x = lookDirection.y * yawSpeed;
            torque.y = lookDirection.x * pitchSpeed;
        }

        public void SetMoveDirection(Vector3 moveDirection)
        {
            thrust = Vector3.forward * moveDirection.y * thrustSpeed;
            torque.z = moveDirection.x * rollSpeed;
        }

        private void ResetVelocity()
        {
            thrust = Vector3.zero;
            torque = Vector3.zero;
        }
    }
}