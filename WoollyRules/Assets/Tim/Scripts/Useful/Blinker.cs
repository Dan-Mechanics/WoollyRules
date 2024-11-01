using UnityEngine;

namespace WoollyRules.Useful
{
    /// <summary>
    /// Inheritence with blinkingtext ?? --> should not a must.
    /// </summary>
    public class Blinker : MonoBehaviour
    {
        [SerializeField] private float interval = 0f;

        protected bool isBlinking;

        protected virtual void Start() 
        {
            Play();
        }

        public virtual void Play() 
        {
            isBlinking = true;

            InvokeRepeating(nameof(Blink), 0f, interval);
        }

        public virtual void Stop() 
        {
            CancelInvoke(nameof(Blink));

            isBlinking = false;
        }

        public virtual void Blink() 
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}