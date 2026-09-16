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

        private void Start()
            => ChangeColor(false, false);

        public void ChangeColor(bool isCuttable, bool ruleBrokenOnCut)
        {
            if (text)
                text.color = ruleBrokenOnCut ? highlightColor : normalColor;

            if (image)
                image.color = ruleBrokenOnCut ? highlightColor : normalColor;
        }
    }
}