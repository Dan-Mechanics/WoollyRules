using UnityEngine;

namespace WoollyRules
{
    public class ScissorsRotator : MonoBehaviour
    {
        [SerializeField] private Scissors scissors = null;
        [SerializeField] private float shakeStrength = 0f;
        [SerializeField] private bool aimAtNothingStartingRot = false;

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
            if (isCuttable)
            {
                transform.LookAt(point);
            }
            else if(aimAtNothingStartingRot)
            {
                transform.localRotation = startingRotation;
            }

            if (isCuttable && !scissors.IsHoveringSheep) { transform.Rotate(Random.insideUnitSphere.normalized * shakeStrength, Space.World); }
        }
    }
}