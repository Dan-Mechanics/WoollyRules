using UnityEngine;

namespace WoollyRules
{
    /// <summary>
    /// FIX: It could maybe make more sense if the position of this object is used as reference.
    /// </summary>
    public class PrefabSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab = null;
        [SerializeField] private Transform spawnExample = null;
        [SerializeField] [Min(0.1f)] private float interval = 0f;
        [SerializeField] private bool spawnWithRandomRotation = false;

        private void Start()
        {
            if (prefab == null) 
            {
                Debug.LogError("There is no prefab assigned.");
                return;
            }
            
            InvokeRepeating(nameof(Spawn), 0f, interval);
        }

        private void Spawn() 
        {
            // very demure code here:
            GameObject newlySpawned = Instantiate(prefab, spawnExample.position, spawnWithRandomRotation ? Random.rotationUniform : spawnExample.rotation);
            newlySpawned.name = prefab.name;
        }
    }
}