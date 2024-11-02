using UnityEngine;

namespace WoollyRules.Sheep
{
    public class SheepAnimation : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb = null;
        [SerializeField] private Transform graphic = null;
        [SerializeField] private float period = 0f;
        [SerializeField] private float verticalMult = 0f;
        [SerializeField] private float verticalOffset = 0f;
        [SerializeField] private float minSpeedToAnimate = 0f;

        private Vector3 startingScale;

        private void Start()
        {
            startingScale = graphic.localScale;
        }
          
        private void FixedUpdate()
        {
            float scale = (Mathf.Sin(Time.time / period) + 1f) / 2f * verticalMult + verticalOffset;
            graphic.localScale = scale * startingScale;
        }
    }
}