using UnityEngine;
using UnityEngine.Events;

namespace WoollyRules
{
    public class Animal : MonoBehaviour, ICuttable
    {
        public enum Type { Sheep, Cow }
        public bool RuleBrokenOnCut => type == Type.Cow;
        public bool IsButton => false;

        [SerializeField] private Type type = default;
        [SerializeField] private Rigidbody rb = default;
        [SerializeField] private Rigidbody[] rigidbodies = default;
        [SerializeField] private UnityEvent onCut = default;

        public void Cut() 
        {
            for (int i = 0; i < rigidbodies.Length; i++)
            {
                Rigidbody temp = rigidbodies[i];
                temp.linearVelocity = rb.linearVelocity;
                temp.angularVelocity = rb.angularVelocity;
            }

            onCut?.Invoke();
        }
    }
}