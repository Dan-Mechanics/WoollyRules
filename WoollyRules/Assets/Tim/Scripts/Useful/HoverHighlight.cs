using UnityEngine;

namespace WoollyRules
{
    public class HoverHighlight : MonoBehaviour
    {
        [SerializeField] private Color highlightColor = Color.clear;
        [SerializeField] private Scissors scissors = null;

        private Color normalColor;

        private void Start()
        {
            normalColor = text.color;

            scissors.OnHoverFeedback += ChangeColor;

            ChangeColor(false, false);
        }

        private void ChangeColor(bool isCuttable, bool ruleBrokenOnCut)
        {
            text.color = ruleBrokenOnCut ? highlightColor : normalColor;
        }
    }
}
