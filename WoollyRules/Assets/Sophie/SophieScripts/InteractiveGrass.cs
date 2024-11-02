using UnityEngine;

namespace WoollyRules.SophieScripts
{
    public class InteractiveGrass : MonoBehaviour
    {
        public Material planetMaterial; // Assign the material
        public GameObject[] entities;   // Array of entities (limit to 4 for performance)

        void Update()
        {
            // Send entity positions to the shader (limiting to 4 positions here)
            for (int i = 0; i < Mathf.Min(entities.Length, 4); i++)
            {
                Vector3 entityPosition = entities[i].transform.position;
                planetMaterial.SetVector($"_EntityPosition{i + 1}", new Vector4(entityPosition.x, entityPosition.y, entityPosition.z, 1.0f)); // Pass positions
            }
        }
    }
}