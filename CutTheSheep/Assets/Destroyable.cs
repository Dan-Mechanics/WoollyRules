using UnityEngine;

namespace CutTheSheep
{
    public class Destroyable : MonoBehaviour
    {
        public void Destroy() { Destroy(gameObject); }
    }
}