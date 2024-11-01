using UnityEngine;

namespace WoollyRules.Core
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject sheepPrefab = null;
        [SerializeField] private GameObject cowPrefab = null;
        [SerializeField] private float cowPercantage = 0f;
        [SerializeField] private CutAllButton cutAllButton = null;
        [SerializeField] [Min(0.1f)] private float interval = 0f;
        [SerializeField] [Min(0)] private int spawnAmount = 0;

        [SerializeField] private bool spawnWithRandomRotation = false;
        [SerializeField] [Min(0f)] private float randomPositionMagnitude = 0f;

        private int spawnCount;

        private void Start()
        {
            if (sheepPrefab == null) 
            {
                Debug.LogError("sheepPrefab is not assigned in the inspector.");
                return;
            }

            if (spawnAmount <= 0)
            {
                Debug.LogWarning("spawnAmount <= 0.");
                return;
            }

            InvokeRepeating(nameof(Spawn), 0f, interval);
        }

        private void Spawn() 
        {   
            Vector3 pos = transform.position + Random.insideUnitSphere * randomPositionMagnitude;
            Quaternion rot = spawnWithRandomRotation ? Random.rotationUniform : transform.rotation;

            // ish ...
            GameObject newlySpawned = Instantiate(Random.value < cowPercantage ? cowPrefab : sheepPrefab, pos, rot);
            newlySpawned.name = sheepPrefab.name;

            Cuttable cuttable = newlySpawned.GetComponent<Cuttable>();
            if (cutAllButton != null && cuttable != null) 
            {
                cutAllButton.Add(cuttable);
            }

            spawnCount++;

            if (spawnCount >= spawnAmount)
            {
                print($"Spawned all the sheep for {gameObject.name}.");
                CancelInvoke(nameof(Spawn));
            }
        }
    }
}