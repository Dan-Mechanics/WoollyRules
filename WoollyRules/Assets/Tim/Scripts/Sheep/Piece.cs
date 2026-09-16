using UnityEngine;

namespace WoollyRules
{
    [RequireComponent(typeof(SplitForce))]
    [RequireComponent(typeof(Destroyable))]
    public class Piece : MonoBehaviour
    {
        [SerializeField] private float destroyTime = default;
        
        public void Split() 
        {
            gameObject.SetActive(true);
            GetComponent<SplitForce>().DoImpact();
            GetComponent<Destroyable>().DestroyAfterTime(destroyTime);
        }
    }
}