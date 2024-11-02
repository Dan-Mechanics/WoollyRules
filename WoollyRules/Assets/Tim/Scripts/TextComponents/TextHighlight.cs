using UnityEngine;
using TMPro;
using WoollyRules.Core;
using UnityEngine.UI;

namespace WoollyRules.TextComponents
{
    public class TextHighlight : MonoBehaviour
    {
        [SerializeField] private TMP_Text text = null;
        [SerializeField] private Image image = null;

        [SerializeField] private Color normalColor = Color.clear;
        [SerializeField] private Color highlightColor = Color.clear;
        [SerializeField] private Scissors scissors = null;

        private void Start()
        {
            //ChangeColor(false, false);
            
            scissors.OnHoverFeedback += ChangeColor;

            ChangeColor(false, false);
        }
        
        private void ChangeColor(bool isCuttable, bool ruleBrokenOnCut)
        {
            if (text != null) { text.color = ruleBrokenOnCut ? highlightColor : normalColor; }
            if (image != null) { image.color = ruleBrokenOnCut ? highlightColor : normalColor; }
        }
    }
}