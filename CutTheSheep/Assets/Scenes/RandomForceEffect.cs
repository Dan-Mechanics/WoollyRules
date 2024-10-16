using UnityEngine;

namespace CutTheSheep
{
    public class RandomForceEffect : MonoBehaviour
    {
        [SerializeField] private float maxSpeedMagnitude = 0f;
        [SerializeField] private Vector3 additionalSpeed = Vector3.zero; 

        public void GiveForce() 
        {
            // !performance
            GetComponent<Rigidbody>().AddForce(additionalSpeed + (Random.insideUnitSphere.normalized * maxSpeedMagnitude), ForceMode.VelocityChange);
        }
    }
}