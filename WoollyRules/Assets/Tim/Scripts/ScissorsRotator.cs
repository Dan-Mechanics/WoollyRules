using UnityEngine;

namespace WoollyRules
{
    public class ScissorsRotator : MonoBehaviour
    {
        [SerializeField] private Scissors scissors = null;
        [SerializeField] private float shakeStrength = 0f;
        [SerializeField] private bool aimAtNothingIsStartingRot = false;

        private Quaternion startingRotation;
        private Vector3 lastPoint;


        /// <summary>
        /// We do it like this because we need the starting rotation in Point().
        /// </summary>
        private void Start()
        {
            startingRotation = transform.localRotation;
            scissors.OnPoint += Point;
        }

        private void Point(bool hasHit, Vector3 point) 
        {
            if (hasHit) { lastPoint = point; }
            else if (aimAtNothingIsStartingRot)
            {
                transform.localRotation = startingRotation;
            }

            if (!aimAtNothingIsStartingRot) { transform.LookAt(lastPoint); }

            // add shake because the scissors is scared.
            if (hasHit && !scissors.IsHoveringSheep) { transform.Rotate(Random.insideUnitSphere.normalized * shakeStrength, Space.World); }
        }
    }
}