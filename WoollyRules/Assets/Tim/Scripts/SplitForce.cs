using UnityEngine;

namespace CutTheSheepTwo
{
    public class SplitForce : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb = null;
        [SerializeField] private float speed = 0f;
        [SerializeField] private float randomSpeed = 0f;

        public void DoImpact() 
        {
            // !performance VVV
            rb.AddForce(Random.insideUnitSphere.normalized * randomSpeed, ForceMode.VelocityChange);

            rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        }
    }
}