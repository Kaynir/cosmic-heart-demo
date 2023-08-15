using UnityEngine;

namespace CosmicHeart.Movement.Moveables
{
    [RequireComponent(typeof(Rigidbody))]
    public class ZeroGravityMoveable : MonoBehaviour, IMoveable
    {
        [Header("Thrust Settings:")]
        [SerializeField] private float thrustSpeed = 10f;
        [SerializeField] private ForceMode thrustForceMode = ForceMode.Acceleration;

        [Header("Torque Settings:")]
        [SerializeField] private Vector3 torqueSpeed = new(1.5f, 1f, 5f);
        [SerializeField] private ForceMode torqueForceMode = ForceMode.Acceleration;

        private Rigidbody body;

        private Vector3 thrust;
        private Vector3 torque;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
            body.useGravity = false;
        }

        private void OnEnable() => ResetVelocity();

        private void FixedUpdate()
        {
            body.AddRelativeForce(thrust, thrustForceMode);
            body.AddRelativeTorque(torque, torqueForceMode);
        }

        public void SetLookDirection(Vector3 lookDirection)
        {
            torque.x = lookDirection.y * torqueSpeed.y;
            torque.y = lookDirection.x * torqueSpeed.x;
        }

        public void SetMoveDirection(Vector3 moveDirection)
        {
            thrust = Vector3.forward * moveDirection.y * thrustSpeed;
            torque.z = moveDirection.x * torqueSpeed.z;
        }

        public void ResetVelocity()
        {
            thrust = Vector3.zero;
            torque = Vector3.zero;
        }
    }
}