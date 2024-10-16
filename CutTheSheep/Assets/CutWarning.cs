using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CutTheSheep
{
    /// <summary>
    /// With warnCount == 0 might not be best performance but I can change later and maybe it doesn't matter at all ...
    /// </summary>
    public class CutWarning : MonoBehaviour
    {
        [SerializeField] private Text text = null;
        [SerializeField] private float warnInterval = 0f;
        [SerializeField] private int warnCount = 0;

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
                if (text.fontStyle != FontStyle.Bold) { text.fontStyle = FontStyle.Bold; }
                else { text.fontStyle = FontStyle.Normal; }

                yield return delay;
            }

            isWarning = false;
        }
    }
}