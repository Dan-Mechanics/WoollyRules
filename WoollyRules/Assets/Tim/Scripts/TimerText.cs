using UnityEngine;
using UnityEngine.UI;

namespace WoollyRules
{
    /// <summary>
    /// 05:50 time meme.
    /// </summary>
    public class TimerText : MonoBehaviour
    {
        [SerializeField] private Text text = null;
        [SerializeField] private Timer timer = null;

        private void FixedUpdate()
        {
            text.enabled = !timer.TimerCompleted;

            // make like 05:50
            text.text = timer.TimeValue.ToString();
        }
    }
}