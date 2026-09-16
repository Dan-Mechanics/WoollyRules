using UnityEngine;
using UnityEngine.Events;

namespace WoollyRules
{
    public class RandomRepeatingEvent : MonoBehaviour
    {
        [SerializeField] private float minTimeBetweenHooks = default;
        [SerializeField] private float maxTimeBetweenHooks = default;
        [SerializeField] private bool hookOnStart = default;
        [SerializeField] private UnityEvent onHook = default;

        private void Start()
        {
            if (hookOnStart)
                onHook?.Invoke();

            if (maxTimeBetweenHooks > 0f)
                Invoke(nameof(Hook), Random.Range(minTimeBetweenHooks, maxTimeBetweenHooks));
        }

        private void Hook() 
        { 
            onHook?.Invoke();
            Invoke(nameof(Hook), Random.Range(minTimeBetweenHooks, maxTimeBetweenHooks));
        }
    }
}
