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

        [SerializeField] private Transform[] spawnPoints = null;

        private int spawnCount;
        private Vector3 pos;

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
            Transform spawnPoint = GetRandomSpawnPoint();
            
            // pemdas for vectors ??
            pos = spawnPoint.position + (Random.insideUnitSphere * randomPositionMagnitude);
            //Quaternion rot = spawnPoint.rotation;

            GameObject newlySpawned = Instantiate(Random.value < cowPercantage ? cowPrefab : sheepPrefab, pos, Quaternion.identity);
            newlySpawned.name = sheepPrefab.name;

            newlySpawned.transform.up = pos.normalized;
            if (spawnWithRandomRotation) { newlySpawned.transform.Rotate(Vector3.up * Random.Range(0f, 360f), Space.Self); }

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
        {
            return spawnPoints[Random.Range(0, spawnPoints.Length)];
        }
    }
}