using UnityEngine;

namespace WoollyRules
{
    public class Destroyable : MonoBehaviour
    {
        public void Destroy() 
            => Destroy(gameObject);

        public void DestroyAfterTime(float time) 
            => Destroy(gameObject, time);
    }
}