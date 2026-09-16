using UnityEngine;
using UnityEngine.Events;

namespace WoollyRules
{
    public class Cuttable : MonoBehaviour, ICuttable
    {
        public bool RuleBrokenOnCut => ruleBrokenOnCut;
        public bool BlockHover => blockHover;
        public bool BlockCut => blockCut;
        public bool IsButton => isButton;

        [SerializeField] private bool blockHover = default;
        [SerializeField] private bool blockCut = default;
        [SerializeField] private bool isButton = default;
        [SerializeField] private bool ruleBrokenOnCut = default; 
        [SerializeField] private UnityEvent onCut = default;
        [SerializeField] private Rigidbody rb = default;
        [SerializeField] private Rigidbody[] rigidbodies = default;
        private Scissors scissors;

        private void Awake()
            => scissors = GameObject.FindWithTag("Scissors").GetComponent<Scissors>();

        public virtual void Cut() 
        {
            for (int i = 0; i < rigidbodies.Length; i++)
            {
                Rigidbody childRigidbody = rigidbodies[i];

                childRigidbody.linearVelocity = rb.linearVelocity;
                childRigidbody.angularVelocity = rb.angularVelocity;
            }

            if (ruleBrokenOnCut && !isButton)
                scissors.BreakRule();

            onCut?.Invoke();
        }
    }
}