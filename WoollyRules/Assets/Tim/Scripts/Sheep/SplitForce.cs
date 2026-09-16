using UnityEngine;

namespace WoollyRules
{
    public class SplitForce : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb = default;
        [SerializeField] private float speed = default;
        [SerializeField] private float randomSpeed = default;

        public void DoImpact() 
        {
            rb.AddForce(Random.insideUnitSphere.normalized * randomSpeed, ForceMode.VelocityChange);
            rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        }
    }
}