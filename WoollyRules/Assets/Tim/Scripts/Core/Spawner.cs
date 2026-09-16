using UnityEngine;

namespace WoollyRules
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab = default;
        [SerializeField] private CutAllButton cutAllButton = default;
        [SerializeField] [Min(0.1f)] private float interval = default;
        [SerializeField] [Min(0)] private int spawnAmount = default;
        [SerializeField] private bool spawnWithRandomRotation = default;
        [SerializeField] [Min(0f)] private float randomPositionMagnitude = default;
        [SerializeField] private Transform[] spawnPoints = default;
        private int spawnCount;
        private Vector3 pos;

        private void Start()
        {
            if (!prefab) 
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
            Transform spawnPoint = GetRandomSpawnPoint();
            pos = spawnPoint.position + (Random.insideUnitSphere * randomPositionMagnitude);

            GameObject newlySpawned = Instantiate(prefab, pos, Quaternion.identity);
            newlySpawned.name = prefab.name;

            newlySpawned.transform.up = pos.normalized;
            if (spawnWithRandomRotation)
                newlySpawned.transform.Rotate(Vector3.up * Random.Range(0f, 360f), Space.Self);

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

        private Transform GetRandomSpawnPoint() 
            => spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}