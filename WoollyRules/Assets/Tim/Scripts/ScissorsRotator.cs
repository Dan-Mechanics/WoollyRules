using UnityEngine;

namespace WoollyRules
{
    public class ScissorsRotator : MonoBehaviour
    {
        [SerializeField] private Scissors scissors = null;
        [SerializeField] private float shakeStrength = 0f;

        /// <summary>
        /// We do it like this because we need the starting rotation in Point().
        /// </summary>
        private void Awake()
        {
            scissors.OnPoint += Point;
        }

        private void Point(bool hasHit, Vector3 point) 
        {
            if (!hasHit) { return; }

            transform.LookAt(point);

            // https://docs.unity3d.com/ScriptReference/Transform.LookAt.html
            // transform.LookAt(target, Vector3.left);

            // add shake because the scissors is scared.
            // if we aint hitting shit then we cant be quivering. like a bithc. 
            if (scissors.IsHoveringRuleBrokenOnCut) { transform.Rotate(Random.insideUnitSphere.normalized * shakeStrength, Space.World); }
        }
    }
}