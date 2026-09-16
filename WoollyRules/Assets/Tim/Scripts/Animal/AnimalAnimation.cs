using UnityEngine;

namespace WoollyRules
{
    public class AnimalAnimation : MonoBehaviour
    {
        [SerializeField] private Transform graphic = default;
        [SerializeField] private Transform state1Graphic = default;
        [SerializeField] private Transform state2Graphic = default;
        [SerializeField] private float period = default;
        [SerializeField] private float waveMult = default;
        private float startingRandomOffset;

        private void Start()
            => startingRandomOffset = Random.Range(0f, 1000f);

        private void FixedUpdate()
        {
            float lerpValue = WaveValue(Time.time + startingRandomOffset) * waveMult;

            graphic.localScale = Vector3.Lerp(state1Graphic.localScale, state2Graphic.localScale, lerpValue);
            graphic.localPosition = Vector3.Lerp(state1Graphic.localPosition, state2Graphic.localPosition, lerpValue);
            graphic.localRotation = Quaternion.Lerp(state1Graphic.localRotation, state2Graphic.localRotation, lerpValue);
        }

        private float WaveValue(float x) 
            => (Mathf.Sin(x / period) + 1f) * 0.5f;
    }
}