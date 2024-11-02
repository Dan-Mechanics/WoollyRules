using UnityEngine;
using UnityEngine.Events;

namespace WoollyRules.Components
{
    public class RandomRepeatingEvent : MonoBehaviour
    {
        [SerializeField] [Min(0.1f)] private float maxTimeBetweenHooks = 0f;
        [SerializeField] private UnityEvent onHook = null;

        private void Start()
        {
            if (maxTimeBetweenHooks <= 0f) { return; }

            Invoke(nameof(Hook), Random.Range(0f, maxTimeBetweenHooks));
        }

        private void Hook() 
        { 
            onHook?.Invoke();
            Invoke(nameof(Hook), Random.Range(0f, maxTimeBetweenHooks));
        }
    }
}
