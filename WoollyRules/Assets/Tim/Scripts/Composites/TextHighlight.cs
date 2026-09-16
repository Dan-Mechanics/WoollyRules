using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WoollyRules
{
    public class TextHighlight : MonoBehaviour
    {
        [SerializeField] private TMP_Text text = default;
        [SerializeField] private Image image = default;
        [SerializeField] private Color normalColor = default;
        [SerializeField] private Color highlightColor = default;
        [SerializeField] private Scissors scissors = default;

        private void Start()
        {
            scissors.OnHoverFeedback += ChangeColor;
            ChangeColor(false, false);
        }
        
        private void ChangeColor(bool isCuttable, bool ruleBrokenOnCut)
        {
            if (text)
                text.color = ruleBrokenOnCut ? highlightColor : normalColor;

            if (image)
                image.color = ruleBrokenOnCut ? highlightColor : normalColor;
        }
    }
}