using UnityEngine;

namespace WoollyRules
{
    public class SheepMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb = default;
        [SerializeField] private float forwardAccel = default;
        [SerializeField] private float maxSpeed = default;
        [SerializeField] private float maxRotationSpeed = default;
        [SerializeField] private Transform forceApplyPoint = default;
        private float rotationDirection;
        private bool isGrounded;

        private void FixedUpdate()
        {
            if (!isGrounded)
                return;

            transform.Rotate(rotationDirection * Time.fixedDeltaTime * Vector3.up, Space.Self);
            rb.AddForceAtPosition(transform.forward * forwardAccel, forceApplyPoint.position, ForceMode.Acceleration);
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
            isGrounded = false;
        }

        private void OnCollisionStay(Collision collision)
            => isGrounded = true;

        public void ChangeRotationDirection() 
            => rotationDirection = Random.Range(-maxRotationSpeed, maxRotationSpeed);
    }
}