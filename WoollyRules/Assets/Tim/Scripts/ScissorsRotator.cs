using UnityEngine;

namespace WoollyRules
{
    public class ScissorsRotator : MonoBehaviour
    {
        [SerializeField] private Scissors scissors = null;
        [SerializeField] private float shakeStrength = 0f;

        private Quaternion startingRotation;

        /// <summary>
        /// We do it like this because we need the starting rotation in Point().
        /// </summary>
        private void Start()
        {
            startingRotation = transform.localRotation;
            scissors.OnPoint += Point;
        }

        private void Point(bool isCuttable, Vector3 point) 
        {
            if (!isCuttable) 
            {
                transform.localRotation = startingRotation;
                return;
            }

            transform.LookAt(point);

            // I could normalize it ...
            if (!scissors.IsHoveringSheep) { transform.Rotate(Random.insideUnitSphere * shakeStrength, Space.World); }
        }
    }
}