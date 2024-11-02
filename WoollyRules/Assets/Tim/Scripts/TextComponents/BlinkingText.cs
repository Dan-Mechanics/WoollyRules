using UnityEngine;
using UnityEngine.UI;
using WoollyRules.Useful;

namespace WoollyRules.TextComponents
{
    public class BlinkingText : Blinker
    {
        [SerializeField] private Text text = null;
        [SerializeField] private Color warnColor = Color.clear;

        [SerializeField] private float minBlinkingTime = 0f;

        private WaitForSeconds delay;

        private void Awake()
        {
            delay = new WaitForSeconds(minBlinkingTime);
        }

        protected override void Start()
        {
            //base.Start();
        }

        public override void Play()
        {
            if (isBlinking) { return; }

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
            //base.Blink();

            if (text.fontStyle != FontStyle.Bold) { text.fontStyle = FontStyle.Bold; text.color = warnColor; }
            else { MakeTextNormal(); }
        }

        private void MakeTextNormal()
        {
            text.fontStyle = FontStyle.Normal; text.color = Color.black;
        }
    }
}