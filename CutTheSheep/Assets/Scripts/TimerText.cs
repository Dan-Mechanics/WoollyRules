using UnityEngine;
using UnityEngine.UI;

namespace CutTheSheep
{
    public class TimerText : MonoBehaviour
    {
        [SerializeField] private Text text = null;

        [SerializeField] private float startingNumber = 0f;

        private void FixedUpdate()
        {
            startingNumber -= Time.fixedDeltaTime;

            text.text = startingNumber.ToString();
        }
    }
}