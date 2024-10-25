using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CutTheSheepTwo
{
    public class PlanetGravity : MonoBehaviour
    {
        private Rigidbody rb;
        private Transform planet;


        private void Start()
        {
            rb = GetComponent<Rigidbody>();

            rb.useGravity = false;
            planet = GameObject.FindWithTag("Planet").transform;
        }

        private void FixedUpdate()
        {
            rb.AddForce((planet.position - transform.position).normalized * Physics.gravity.magnitude, ForceMode.Acceleration);
        }
    }
}