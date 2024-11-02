using UnityEngine;

namespace WoollyRules.Sheep
{
    public class SheepAnimation : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb = null;
        [SerializeField] private Transform graphic = null;

        [SerializeField] private Transform state1Graphic = null;
        [SerializeField] private Transform state2Graphic = null;

        [SerializeField] private SheepMovement sheepMovement = null;
        [SerializeField] private float period = 0f;
        [SerializeField] private float waveMult = 0f;

        private float startingRandomOffset;

        private void Start()
        {
            startingRandomOffset = Random.Range(0f, 1000f);
        }
        
        private void FixedUpdate()
        {
            float lerpValue = WaveValue(Time.time + startingRandomOffset) * waveMult;

            graphic.localScale = Vector3.Lerp(state1Graphic.localScale, state2Graphic.localScale, lerpValue);
            graphic.localPosition = Vector3.Lerp(state1Graphic.localPosition, state2Graphic.localPosition, lerpValue);
            graphic.localRotation = Quaternion.Lerp(state1Graphic.localRotation, state2Graphic.localRotation, lerpValue);
        }

        private float WaveValue(float x) 
        {
            return (Mathf.Sin(x / period) + 1f) / 2f;
        }
    }
}