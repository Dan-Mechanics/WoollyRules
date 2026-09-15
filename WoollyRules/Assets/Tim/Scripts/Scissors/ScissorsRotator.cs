using System;
using UnityEngine;

namespace WoollyRules
{
    public class ScissorsRotator : MonoBehaviour
    {
        public Func<bool> GetIsWarning;
        [SerializeField] private float shakeStrength = default;
        [SerializeField] private Transform cameraRotator = default;

        public void PointTo(bool hasHit, Vector3 point) 
        {
            if (!hasHit)
                return;

            transform.LookAt(point, cameraRotator.up);
            if (GetIsWarning()) 
                transform.Rotate(UnityEngine.Random.insideUnitSphere.normalized * shakeStrength, Space.World);
        }
    }
}