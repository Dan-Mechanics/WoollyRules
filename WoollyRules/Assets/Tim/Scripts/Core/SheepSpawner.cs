using UnityEngine;

namespace WoollyRules.Core
{
    public class SheepSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject sheepPrefab = null;
        [SerializeField] private CutAllButton cuttableHolder = null;
        [SerializeField] [Min(0.1f)] private float interval = 0f;
        [SerializeField] [Min(0)] private int amountOfSheepToSpawn = 0;

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

            if (amountOfSheepToSpawn <= 0)
            {
                Debug.LogWarning("amountOfSheepToSpawn <= 0.");
                return;
            }

            InvokeRepeating(nameof(Spawn), 0f, interval);
        }

        private void Spawn() 
        {   
            Vector3 pos = transform.position + Random.insideUnitSphere * randomPositionMagnitude;
            Quaternion rot = spawnWithRandomRotation ? Random.rotationUniform : transform.rotation;

            GameObject newSheep = Instantiate(sheepPrefab, pos, rot);
            newSheep.name = sheepPrefab.name;

            Cuttable cuttable = newSheep.GetComponent<Cuttable>();
            if (cuttableHolder != null && cuttable != null) 
            {
                cuttableHolder.Add(cuttable);
            }

            spawnCount++;

            if (spawnCount >= amountOfSheepToSpawn)
            {
                print($"Spawned all the sheep for {gameObject.name}.");
                CancelInvoke(nameof(Spawn));
            }
        }
    }
}