using UnityEngine;

namespace CutTheSheep
{
    public class PrefabSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab = null;
        [SerializeField] private Transform spawnExample = null;
        [SerializeField] [Min(0.1f)] private float interval = 0f;

        private void Start()
        {
            InvokeRepeating(nameof(Spawn), 0f, interval);
        }

        private void Spawn() 
        {
            GameObject newlySpawned = Instantiate(prefab, spawnExample.position, spawnExample.rotation);
            newlySpawned.name = prefab.name;
        }
    }
}