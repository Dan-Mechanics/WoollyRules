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

        private Rigidbody rb;
        private Transform planet;


        private void Start()
        {
            rb = GetComponent<Rigidbody>();

            rb.useGravity = false;
            planet = GameObject.FindWithTag("Planet").transform;

            //if (graphic == null) { Debug.LogError("if (graphic == null) !!"); Destroy(gameObject); }
        }

        private void FixedUpdate()
        {
            Vector3 accel = (planet.position - transform.position).normalized * Physics.gravity.magnitude;


            rb.AddForce(accel, ForceMode.Acceleration);

            // hope this works ...
            if (orientSelfAgainstGravity) { graphic.up = -accel.normalized; }
        }
    }
}