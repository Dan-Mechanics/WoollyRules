using UnityEngine;

namespace WoollyRules
{
    public class SheepMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb = null;
       // [SerializeField] private Transform graphic = null;
        //[SerializeField] private float bouncePeriod = 0f;
        [SerializeField] private float forwardAccel = 0f;
        [SerializeField] private float maxSpeed = 0f;
        [SerializeField] private float maxRotationSpeed = 0f;
        [SerializeField] private float rotationDirectionChangeInterval = 0f;
        /*[SerializeField] private float minScaleMod = 0f;
        [SerializeField] private float maxScaleMod = 0f;
        [SerializeField] private float minSpeedToAnimate = 0f;*/

        //private Vector3 startingScale;
        private float rotationDirection;

        private void Start()
        {
            //startingScale = graphic.localScale;

            InvokeRepeating(nameof(ChangeRotationDirection), 0f, rotationDirectionChangeInterval);
        }

        private void FixedUpdate()
        {
            //graphic.localScale = startingScale * Mathf.Lerp(minScaleMod, maxScaleMod, Mathf.Sin(Time.time * bouncePeriod));

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