using UnityEngine;

namespace WoollyRules.Sheep
{
    /// <summary>
    /// Link with sheep animation with property
    /// make the rotation better.
    /// </summary>
    public class SheepMovement : MonoBehaviour
    {
        public float FlatSpeed { get; private set; }

        [SerializeField] private Rigidbody rb = null;
        [SerializeField] private float forwardAccel = 0f;
        [SerializeField] private float maxSpeed = 0f;
        [SerializeField] private float maxRotationSpeed = 0f;
        [SerializeField] private float maxChangeDirInterval = 0f;
        [SerializeField] private Transform forceApplyPoint = null;

        private float rotationDirection;
        private Vector3 velocity;

        private void Start()
        {
            Invoke(nameof(ChangeRotationDirection), Random.Range(0f, maxChangeDirInterval));
        }

        private void FixedUpdate()
        {
            transform.Rotate(rotationDirection * Time.fixedDeltaTime * Vector3.up, Space.Self);

            rb.AddForceAtPosition(transform.forward * forwardAccel, forceApplyPoint.position, ForceMode.Acceleration);

            velocity = rb.linearVelocity;

            // idk if this is the right one.
            velocity = transform.InverseTransformDirection(velocity);
            velocity.y = 0f;

            FlatSpeed = velocity.magnitude;

            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
            velocity = transform.TransformDirection(velocity);
            velocity.y = rb.linearVelocity.y;

            rb.linearVelocity = velocity;
        }

        private void ChangeRotationDirection() 
        {
            rotationDirection = Random.Range(-maxRotationSpeed, maxRotationSpeed);

            Invoke(nameof(ChangeRotationDirection), Random.Range(0f, maxChangeDirInterval));
        }
    }
}