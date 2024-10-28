using UnityEngine;

namespace WoollyRules
{
    /// <summary>
    /// TODO: refactor.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlanetGravity : MonoBehaviour
    {
        //[SerializeField] private bool orientSelfAgainstGravity = false;
        //[SerializeField] private Transform graphic = null;
        //[SerializeField] private float graphicRotation = 0f;

        //[SerializeField] private bool standUpRight = false;   
        [SerializeField] private float standUprightTorque = 0f;

        private Rigidbody rb;
        private Transform planet;


        private void Start()
        {
            rb = GetComponent<Rigidbody>();

            rb.useGravity = false;
            planet = GameObject.FindWithTag("Planet").transform;

            //graphicRotation = Random.Range(0f, 360f);

            //if (graphic == null) { Debug.LogError("if (graphic == null) !!"); Destroy(gameObject); }
        }

        /// <summary>
        /// This is totally fine ...
        /// </summary>
        private void FixedUpdate()
        {
            Vector3 gravity = (planet.position - transform.position).normalized * Physics.gravity.magnitude;

            rb.AddForce(gravity, ForceMode.Acceleration);

            // hope this works ...
            /*if (orientSelfAgainstGravity)
            {
                graphic.up = -accel.normalized;
                graphic.Rotate(Vector3.up * graphicRotation, Space.Self);
            }*/

            // yippie performnance !!!
            if (standUprightTorque > 0f) { StandUpright(gravity); }
        }

        /// <summary>
        /// https://discussions.unity.com/t/rotate-rigidbody-with-addtorque-towards-a-specific-location/792692/3
        /// 
        /// Don't ask it just works. (tm)
        /// </summary>
        private void StandUpright(Vector3 gravity) 
        {
            rb.AddTorque(Vector3.Cross(gravity.normalized, transform.up) * standUprightTorque, ForceMode.Acceleration);
        }
    }
}