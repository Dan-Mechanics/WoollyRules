using UnityEngine;

namespace WoollyRules
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlanetGravity : MonoBehaviour
    { 
        [SerializeField] private float standUprightTorque = default;
        private Rigidbody rb;
        private Transform planet;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            planet = GameObject.FindWithTag("Planet").transform;
            rb.useGravity = false;
        }

        private void FixedUpdate()
        {
            Vector3 gravity = (planet.position - transform.position).normalized * Physics.gravity.magnitude;
            rb.AddForce(gravity, ForceMode.Acceleration);
            if (standUprightTorque > 0f)
                SelfCenter(gravity);
        }

        /// <summary>
        /// https://discussions.unity.com/t/rotate-rigidbody-with-addtorque-towards-a-specific-location/792692/3
        /// </summary>
        private void SelfCenter(Vector3 gravity) 
            => rb.AddTorque(Vector3.Cross(gravity.normalized, transform.up) * standUprightTorque, ForceMode.Acceleration);
    }
}