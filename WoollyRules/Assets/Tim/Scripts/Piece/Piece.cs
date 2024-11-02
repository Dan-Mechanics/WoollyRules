using UnityEngine;

namespace WoollyRules.Piece
{
    [RequireComponent(typeof(SplitForce))]
    [RequireComponent(typeof(Destroyable))]
    public class Piece : MonoBehaviour
    {
        [SerializeField] private float destroyTime = 0f;
        
        public void Split() 
        {
            gameObject.SetActive(true);
            GetComponent<SplitForce>().DoImpact();
            GetComponent<Destroyable>().DestroyAfterTime(destroyTime);
        }
    }
}