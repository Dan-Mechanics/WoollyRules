using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CutTheSheep
{
    /// <summary>
    /// With warnCount == 0 might not be best performance but I can change later and maybe it doesn't matter at all ...
    /// MAYBE: rename to TextWarning.cs or something and make it work for the timer also to make it feel more threatening.
    /// </summary>
    public class CutWarning : MonoBehaviour
    {
        [SerializeField] private Text text = null;
        [SerializeField] private float warnInterval = 0f;
        [SerializeField] private int warnCount = 0;
        [SerializeField] private Color warnColor = Color.clear;

        private bool isWarning;
        private WaitForSeconds delay;

        private void Start()
        {
            delay = new WaitForSeconds(warnInterval / 2f);
        }

        [ContextMenu("Warn()")]
        public void Warn()
        {
            if (isWarning) { return; }

            isWarning = true;

            StartCoroutine(WarnDelayed());
        }

        /// <summary>
        /// This is a coroutine that makes the text bold and not bold.
        /// </summary>
        private IEnumerator WarnDelayed()
        {
            for (int i = 0; i < warnCount * 2; i++)
            {
                if (text.fontStyle != FontStyle.Bold) { text.fontStyle = FontStyle.Bold; text.color = warnColor; }
                else { text.fontStyle = FontStyle.Normal; text.color = Color.black; }

                yield return delay;
            }

            isWarning = false;
        }
    }
}