using UnityEngine;
using UnityEngine.Events;

namespace WoollyRules
{
    public class Timer : MonoBehaviour
    {
        public float TimeValue => timeValue;
        public bool TimerCompleted => timerCompleted;

        [SerializeField] private float timeValue = 0f;
        [SerializeField] private UnityEvent onTimerComplete = null;

        private bool timerCompleted;

        private void FixedUpdate()
        {
            if (timerCompleted)
                return;
            
            timeValue -= Time.fixedDeltaTime;

            if (timeValue <= 0f) 
            { 
                timeValue = 0f;
                onTimerComplete?.Invoke();
                timerCompleted = true;
            }
        }

        public void SetTimer(float timeValue) 
        {
            this.timeValue = timeValue;
            timerCompleted = false;
            gameObject.SetActive(true);
        }
    }
}