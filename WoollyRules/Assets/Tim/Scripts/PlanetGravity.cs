using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace WoollyRules
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlanetGravity : MonoBehaviour
    {
        [SerializeField] private bool orientSelfAgainstGravity = false;
        [SerializeField] private Transform graphic = null;
        [SerializeField] private float graphicRotation = 0f;

        [SerializeField] private bool selfCenter = false;   
        [SerializeField] private float selfCenterTorque = 0f;

        private Rigidbody rb;
        private Transform planet;


        private void Start()
        {
            rb = GetComponent<Rigidbody>();

            rb.useGravity = false;
            planet = GameObject.FindWithTag("Planet").transform;

            graphicRotation = Random.Range(0f, 360f);

            //if (graphic == null) { Debug.LogError("if (graphic == null) !!"); Destroy(gameObject); }
        }

        /// <summary>
        /// This is totally fine ...
        /// </summary>
        private void FixedUpdate()
        {
            Vector3 accel = (planet.position - transform.position).normalized * Physics.gravity.magnitude;


            rb.AddForce(accel, ForceMode.Acceleration);

            // hope this works ...
            if (orientSelfAgainstGravity)
            {
                graphic.up = -accel.normalized;
                graphic.Rotate(Vector3.up * graphicRotation, Space.Self);
            }

            if (selfCenter) 
            {
                Vector3 ideal = accel.normalized;

                Vector3 current = transform.up;

                Vector3 torque = Vector3.Cross(ideal, current);
                rb.AddTorque(torque * selfCenterTorque, ForceMode.Acceleration);
            }
        }
    }
}