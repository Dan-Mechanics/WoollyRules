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

                // make like 05:50
                text.text = timer.TimeValue.ToString();
            }

            if (tmp != null) 
            {
                tmp.enabled = !timer.TimerCompleted;

                // make like 05:50
                tmp.text = timer.TimeValue.ToString();
            }
        }
    }
}