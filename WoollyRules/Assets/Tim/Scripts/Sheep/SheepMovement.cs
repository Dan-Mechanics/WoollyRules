using UnityEngine;

namespace WoollyRules.Sheep
{
    public class SheepMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb = null;
        [SerializeField] private float forwardAccel = 0f;
        [SerializeField] private float maxSpeed = 0f;
        [SerializeField] private float maxRotationSpeed = 0f;
        [SerializeField] private Transform forceApplyPoint = null;

        private float rotationDirection;
        private bool isGrounded;

        private void FixedUpdate()
        {
            if (!isGrounded) { return; }

            transform.Rotate(rotationDirection * Time.fixedDeltaTime * Vector3.up, Space.Self);

            rb.AddForceAtPosition(transform.forward * forwardAccel, forceApplyPoint.position, ForceMode.Acceleration);

            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);

            isGrounded = false;
        }

        private void OnCollisionStay(Collision collision)
        {
            isGrounded = true;
        }

        public void ChangeRotationDirection() 
        {
            rotationDirection = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        }
    }
}