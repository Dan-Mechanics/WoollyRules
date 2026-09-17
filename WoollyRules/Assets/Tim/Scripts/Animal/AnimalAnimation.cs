using UnityEngine;

namespace WoollyRules
{
    public class AnimalAnimation : MonoBehaviour
    {
        [SerializeField] private Transform graphic = default;
        [SerializeField] private Transform upBounce = default;
        [SerializeField] private Transform downBounce = default;
        [SerializeField] private float period = default;
        [SerializeField] private float waveMult = default;
        private float startingRandomOffset;

        private void Start()
            => startingRandomOffset = Random.Range(0f, 1000f);

        private void FixedUpdate()
        {
            float lerpValue = WaveValue(Time.time + startingRandomOffset) * waveMult;

            graphic.localScale = Vector3.Lerp(upBounce.localScale, downBounce.localScale, lerpValue);
            graphic.localPosition = Vector3.Lerp(upBounce.localPosition, downBounce.localPosition, lerpValue);
            graphic.localRotation = Quaternion.Lerp(upBounce.localRotation, downBounce.localRotation, lerpValue);
        }

        private float WaveValue(float x) 
            => (Mathf.Sin(x / period) + 1f) * 0.5f;
    }
}