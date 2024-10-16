using UnityEngine;

namespace CutTheSheep
{
    public class Destroyable : MonoBehaviour
    {
        [Tooltip("If this value <= 0f then will not destroy with time.")]
        [SerializeField] private float destroyAfterTime = 0f;

        private void Start()
        {
            if (destroyAfterTime <= 0f) { return; }

            Destroy(gameObject, destroyAfterTime);
        }

        public void Destroy() { Destroy(gameObject); }
    }
}