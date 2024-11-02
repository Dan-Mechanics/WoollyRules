using UnityEngine;

namespace WoollyRules.Sheep
{
    public class SheepAnimation : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb = null;
        [SerializeField] private Transform graphic = null;
        [SerializeField] private SheepMovement sheepMovement = null;
        [SerializeField] private float period = 0f;
        [SerializeField] private float verticalMult = 0f;
        [SerializeField] private float verticalOffset = 0f;
        //[SerializeField] private float minSpeedToAnimate = 0f;

        private Vector3 startingScale;
        private float startingRandomOffset;

        private void Start()
        {
            startingScale = graphic.localScale;

            // these numbers dont really matter just need to be biggerthan 2PI i think.
            startingRandomOffset = Random.Range(-100f, 100f);
        }
          
        private void FixedUpdate()
        {
            float scale = (Mathf.Sin((Time.time + startingRandomOffset) / period) + 1f) / 2f * verticalMult + verticalOffset;
            graphic.localScale = scale * startingScale;

            /*if (sheepMovement.FlatSpeed >= minSpeedToAnimate)
            {
                float scale = (Mathf.Sin((Time.time + startingRandomOffset) / period) + 1f) / 2f * verticalMult + verticalOffset;
                graphic.localScale = scale * startingScale;
            }
            else 
            {
                graphic.localScale = startingScale;
            }*/
        }
    }
}