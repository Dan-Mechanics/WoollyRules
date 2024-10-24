using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

namespace CutTheSheep
{
    /// <summary>
    /// NEXT THING TO ADD: GLOBE !!
    /// </summary>
    public class TextStretcher : MonoBehaviour
    {
        [SerializeField] private TMP_Text text = null;
        [SerializeField] private float spacingPerSecond = 0f;

        private void FixedUpdate()
        {
            text.characterSpacing += spacingPerSecond * Time.fixedDeltaTime;
        }
    }
}