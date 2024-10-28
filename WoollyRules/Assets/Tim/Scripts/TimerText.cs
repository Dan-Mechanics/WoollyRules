using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace WoollyRules
{
    public class TimerText : MonoBehaviour
    {
        [SerializeField] private UnityEvent onTimerDone = null;
        
        [SerializeField] private Text text = null;

        [SerializeField] private float startingNumber = 0f;

        private bool done;

        private void FixedUpdate()
        {
            if (done) { return; }

            startingNumber -= Time.fixedDeltaTime;

            if (startingNumber <= 0f) 
            {
                startingNumber = 0f;
                onTimerDone?.Invoke();
                text.text = startingNumber.ToString();
                done = true;
                //Destroy(this);
            }

            text.text = startingNumber.ToString();
        }
    }
}