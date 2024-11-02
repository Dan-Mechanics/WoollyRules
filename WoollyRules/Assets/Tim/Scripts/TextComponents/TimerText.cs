using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using WoollyRules.Useful;

namespace WoollyRules.TextComponents
{
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
                text.text = GetTimerString(timer.TimeValue);
            }

            if (tmp != null) 
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
            if (seconds > TimeSpan.MaxValue.TotalSeconds) { seconds = TimeSpan.MaxValue.TotalSeconds; }
            
            TimeSpan time = TimeSpan.FromSeconds(seconds);

            return time.ToString(@"mm\:ss\:ff");

            //return time.ToString(@"hh\:mm\:ss\:fff");
        }
    }
}