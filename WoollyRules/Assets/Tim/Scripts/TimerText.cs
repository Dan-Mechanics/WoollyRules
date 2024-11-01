using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace WoollyRules
{
    /// <summary>
    /// 05:50 time meme.
    /// </summary>
    public class TimerText : MonoBehaviour
    {
        [SerializeField] private Text text = null;
        [SerializeField] private TMP_Text tmp = null;

        [SerializeField] private Timer timer = null;

        private void FixedUpdate()
        {
            if (text != null)
            {
                text.enabled = !timer.TimerCompleted;
                text.text = GetTimerString();
            }

            if (tmp != null) 
            {
                tmp.enabled = !timer.TimerCompleted;
                tmp.text = GetTimerString();
            }
        }

        private string GetTimerString()
        {
            float seconds = timer.TimeValue;
            float minutes = seconds % 60;
            seconds -= minutes * 60f;

            //seconds = Mathf.Ceil(seconds);
            //minutes = Mathf.Ceil(minutes);

            return $"{minutes}:{seconds}";
        }
    }
}