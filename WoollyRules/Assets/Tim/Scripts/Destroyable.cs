using UnityEngine;

namespace WoollyRules
{
    /// <summary>
    /// should make it so we have bool here with insta destroy or time perhaps ??
    /// or maybe just remove the idea of destroing from start in the first place like damn
    /// </summary>
    public class Destroyable : MonoBehaviour
    {
        //[Tooltip("If this value <= 0f then will not destroy with time.")]
        //[SerializeField] private float destroyTime = 0f; // was 0f.

        /*private void Start()
        {
            if (destroyTime <= 0f) { return; }

            DestroyAfterTime(destroyTime);
        }*/

        public void Destroy() { Destroy(gameObject); }

        public void DestroyAfterTime(float time) { Destroy(gameObject, time); }
    }
}