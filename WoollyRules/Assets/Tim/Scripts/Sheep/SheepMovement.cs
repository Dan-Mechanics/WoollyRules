using UnityEngine;

namespace WoollyRules.Sheep
{
    /// <summary>
    /// Link with sheep animation with property
    /// make the rotation better.
    /// </summary>
    public class SheepMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb = null;
        [SerializeField] private float forwardAccel = 0f;
        [SerializeField] private float maxSpeed = 0f;
        [SerializeField] private float maxRotationSpeed = 0f;
        [SerializeField] private Transform forceApplyPoint = null;

        private float rotationDirection;
        private Vector3 velocity;
        private bool isGrounded;

        private void FixedUpdate()
        {
            if (isGrounded) 
            {
                transform.Rotate(rotationDirection * Time.fixedDeltaTime * Vector3.up, Space.Self);

                rb.AddForceAtPosition(transform.forward * forwardAccel, forceApplyPoint.position, ForceMode.Acceleration);
            }

            velocity = rb.linearVelocity;

            // idk if this is the right one.
            velocity = transform.InverseTransformDirection(velocity);
            velocity.y = 0f;

            //FlatSpeed = velocity.magnitude;

            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
            velocity = transform.TransformDirection(velocity);
            velocity.y = rb.linearVelocity.y;

            rb.linearVelocity = velocity;

            isGrounded = false;
        }

        private void OnCollisionStay(Collision collision)
        {
            isGrounded = true;
        }

        public void ChangeRotationDirection() 
        {
            rotationDirection = Random.Range(-maxRotationSpeed, maxRotationSpeed);

            //Invoke(nameof(ChangeRotationDirection), Random.Range(0f, maxChangeDirInterval));
        }
    }
}