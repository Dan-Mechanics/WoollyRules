using UnityEngine;
using UnityEngine.Events;

namespace CutTheSheep
{
    public class Cuttable : MonoBehaviour
    {
        [SerializeField] private bool isSheep = false;
        [SerializeField] private UnityEvent onCut = null;

        [SerializeField] private Rigidbody rb = null;
        [SerializeField] private Rigidbody[] rigidbodies = null;

        public virtual void Cut() 
        {
            // idk if this works.
            for (int i = 0; i < rigidbodies.Length; i++)
            {
                /*rigidbodies[i].AddForce(rb.velocity, ForceMode.VelocityChange);
                rigidbodies[i].AddTorque(rb.angularVelocity, ForceMode.VelocityChange);*/

                // maybe this works better ?
                // yep that fixed it V

                Rigidbody childRigidbody = rigidbodies[i];

                childRigidbody.linearVelocity = rb.linearVelocity;
                childRigidbody.angularVelocity = rb.angularVelocity;
            }
            
            onCut?.Invoke();
        }


        public bool GetIsSheep() { return isSheep; }
    }
}