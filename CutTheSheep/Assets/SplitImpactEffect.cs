using UnityEngine;

namespace CutTheSheep
{
    public class SplitImpactEffect : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb = null;
        [SerializeField] private float speed = 0f;
        [SerializeField] private float randomSpeed = 0f;
        //[SerializeField] private Vector3 additionalSpeed = Vector3.zero; 

        public void DoImpact() 
        {
            // !performance VVV
            GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere.normalized * randomSpeed, ForceMode.VelocityChange);

            rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        }
    }
}