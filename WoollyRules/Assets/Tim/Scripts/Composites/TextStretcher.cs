using TMPro;
using UnityEngine;

namespace WoollyRules
{
    public class TextStretcher : MonoBehaviour
    {
        [SerializeField] private TMP_Text text = default;
        [SerializeField] private float spacingPerSecond = default;
        [SerializeField] private float min = default;
        [SerializeField] private float max = default;

        private void FixedUpdate()
        {
            text.characterSpacing += spacingPerSecond * Time.fixedDeltaTime;
            text.characterSpacing = Mathf.Clamp(text.characterSpacing, min, max);
        }
    }
}