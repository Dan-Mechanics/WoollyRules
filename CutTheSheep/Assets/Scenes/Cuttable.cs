using UnityEngine;
using UnityEngine.Events;

namespace CutTheSheep
{
    public class Cuttable : MonoBehaviour
    {
        [SerializeField] private bool isSheep = false;
        [SerializeField] private UnityEvent onCut = null;

        public virtual void Cut() 
        {
            onCut?.Invoke();
        }


        public bool GetIsSheep() { return isSheep; }
    }
}