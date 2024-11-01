using UnityEngine;

namespace WoollyRules.Piece
{
    /// <summary>
    /// should make it so we have bool here with insta destroy or time perhaps ??
    /// or maybe just remove the idea of destroing from start in the first place like damn
    /// 
    /// disabler.
    /// </summary>
    public class Destroyable : MonoBehaviour
    {
        public void Destroy() { Destroy(gameObject); }

        public void DestroyAfterTime(float time) { Destroy(gameObject, time); }
    }
}