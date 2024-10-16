using UnityEngine;

namespace CutTheSheep
{
    public class Destroyable : MonoBehaviour
    {
        [Tooltip("If this value <= 0f then will not destroy with time.")]
        [SerializeField] private float destroyTime = 0f;

        private void Start()
        {
            if (destroyTime <= 0f) { return; }

            DestroyAfterTime(destroyTime);
        }

        public void Destroy() { Destroy(gameObject); }

        public void DestroyAfterTime(float time) { Destroy(gameObject, time); }
    }
}