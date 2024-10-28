using UnityEngine;
using UnityEngine.Events;

namespace WoollyRules
{
    public class Cuttable : MonoBehaviour, ICuttable
    {
        public bool IsSheep => isSheep;
        
        [SerializeField] private bool isSheep = false;
        [SerializeField] private UnityEvent onCut = null;

        [SerializeField] private Rigidbody rb = null;
        [SerializeField] private Rigidbody[] rigidbodies = null;

        public virtual void Cut() 
        {
            for (int i = 0; i < rigidbodies.Length; i++)
            {
                Rigidbody childRigidbody = rigidbodies[i];

                childRigidbody.linearVelocity = rb.linearVelocity;
                childRigidbody.angularVelocity = rb.angularVelocity;
            }
            
            onCut?.Invoke();
        }
    }
}