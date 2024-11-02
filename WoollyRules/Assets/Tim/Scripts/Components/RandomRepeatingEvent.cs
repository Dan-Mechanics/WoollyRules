using UnityEngine;
using UnityEngine.Events;

namespace WoollyRules.Components
{
    public class RandomRepeatingEvent : MonoBehaviour
    {
        [SerializeField] private float minTimeBetweenHooks = 0f;
        [SerializeField] [Min(0.5f)] private float maxTimeBetweenHooks = 0f;
        [SerializeField] private bool hookOnStart = false;
        [SerializeField] private UnityEvent onHook = null;

        private void Start()
        {
            if (hookOnStart) { onHook?.Invoke(); }

            if (maxTimeBetweenHooks <= 0f) { return; }

            Invoke();
        }

        private void Invoke()
        {
            Invoke(nameof(Hook), Random.Range(minTimeBetweenHooks, maxTimeBetweenHooks));
        }

        private void Hook() 
        { 
            onHook?.Invoke();
            Invoke();
        }
    }
}
