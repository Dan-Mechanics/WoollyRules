using UnityEngine;

namespace WoollyRules
{
    /// <summary>
    /// Inheritence with blinkingtext ?? --> should not a must.
    /// </summary>
    public class Blinker : MonoBehaviour
    {
        [SerializeField] private float interval = 0f;

        protected virtual void Start() 
        {
            Play();
        }

        public virtual void Play() 
        {
            InvokeRepeating(nameof(Blink), 0f, interval);
        }

        public virtual void Stop() 
        {
            CancelInvoke(nameof(Blink));
        }

        public virtual void Blink() 
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}