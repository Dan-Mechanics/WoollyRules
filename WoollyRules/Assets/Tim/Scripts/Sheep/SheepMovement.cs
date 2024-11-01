using UnityEngine;

namespace WoollyRules.Sheep
{
    public class SheepMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb = null;
        [SerializeField] private float forwardAccel = 0f;
        [SerializeField] private float maxSpeed = 0f;
        [SerializeField] private float maxRotationSpeed = 0f;
        [SerializeField] private float rotationDirectionChangeInterval = 0f;

        private float rotationDirection;

        private void Start()
        {
            InvokeRepeating(nameof(ChangeRotationDirection), 0f, rotationDirectionChangeInterval);
        }

        private void FixedUpdate()
        {
            Vector3 vel = rb.linearVelocity;

            // idk if this is the right one.
            vel = transform.InverseTransformDirection(vel);
            vel.y = 0f;

            transform.Rotate(rotationDirection * Time.fixedDeltaTime * Vector3.up, Space.Self);

            rb.AddForce(transform.forward * forwardAccel, ForceMode.Acceleration);

            vel = Vector3.ClampMagnitude(vel, maxSpeed);
            vel = transform.TransformDirection(vel);
            vel.y = rb.linearVelocity.y;

            rb.linearVelocity = vel;
        }

        private void ChangeRotationDirection() 
        {
            rotationDirection = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        }
    }
}