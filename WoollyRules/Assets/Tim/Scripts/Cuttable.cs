using UnityEngine;
using UnityEngine.Events;

namespace WoollyRules
{
    /// <summary>
    /// Perhaps should be called scissor interactable.
    /// </summary>
    public class Cuttable : MonoBehaviour
    {
        public bool RuleBrokenOnCut => ruleBrokenOnCut;
        public bool BlockHover => blockHover;
        public bool BlockCut => blockCut;

        [SerializeField] private bool blockHover = false;
        [SerializeField] private bool blockCut = false;

        [SerializeField] private bool ruleBrokenOnCut = false; // this should be something like ruleBrokenOnCut

        /// <summary>
        /// NOTE: we have to do the same things to the cut piece twice. this is not ideal.
        /// </summary>
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