using TMPro;
using UnityEngine;

namespace WoollyRules.Components
{
    public class TextStretcher : MonoBehaviour
    {
        [SerializeField] private TMP_Text text = null;
        [SerializeField] private float spacingPerSecond = 0f;
        [SerializeField] private float min = 0f;
        [SerializeField] private float max = 0f;

        private void FixedUpdate()
        {
            text.characterSpacing += spacingPerSecond * Time.fixedDeltaTime;
            text.characterSpacing = Mathf.Clamp(text.characterSpacing, min, max);
        }
    }
}