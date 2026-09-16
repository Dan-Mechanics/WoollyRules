using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace WoollyRules
{
    public class TimerText : MonoBehaviour
    {
        [SerializeField] private Text text = default;
        [SerializeField] private TMP_Text tmp = default;
        [SerializeField] private Timer timer = default;

        private void FixedUpdate()
        {
            if (text)
            {
                text.enabled = !timer.TimerCompleted;
                text.text = GetTimerString(timer.TimeValue);
            }

            if (tmp) 
            {
                tmp.enabled = !timer.TimerCompleted;
                tmp.text = GetTimerString(timer.TimeValue);
            }
        }

        /// <summary>
        /// https://stackoverflow.com/questions/463642/how-can-i-convert-seconds-into-hourminutessecondsmilliseconds-time
        /// </summary>
        private string GetTimerString(double seconds)
        {
            if (seconds > TimeSpan.MaxValue.TotalSeconds)
                seconds = TimeSpan.MaxValue.TotalSeconds;

            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return time.ToString(@"mm\:ss\:ff");
        }
    }
}