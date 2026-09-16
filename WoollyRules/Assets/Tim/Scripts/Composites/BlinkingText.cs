using UnityEngine;
using UnityEngine.UI;

namespace WoollyRules
{
    public class BlinkingText : Blinker
    {
        [SerializeField] private Text text = default;
        [SerializeField] private Color warnColor = default;
        [SerializeField] private float minBlinkingTime = default;
        private WaitForSeconds delay;

        private void Awake()
            => delay = new WaitForSeconds(minBlinkingTime);

        public override void Play()
        {
            if (isBlinking)
                return;

            base.Play();
            Invoke(nameof(Stop), minBlinkingTime);
        }

        public override void Stop()
        {
            base.Stop();
            MakeTextNormal();
        }

        public override void Blink()
        {
            if(text.fontStyle == FontStyle.Bold)
            {
                MakeTextNormal();
                return;
            }

            text.fontStyle = FontStyle.Bold;
            text.color = warnColor;
        }

        private void MakeTextNormal()
            => text.fontStyle = FontStyle.Normal; text.color = Color.black;
    }
}