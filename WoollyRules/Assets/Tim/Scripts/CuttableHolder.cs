using System.Collections.Generic;
using UnityEngine;

namespace WoollyRules
{
    /// <summary>
    /// You always need to ask yourself: how does this contribute to the intention ??
    /// </summary>
    public class CuttableHolder : MonoBehaviour
    {
        [Header("The question is wether we want the bear in this.")]
        [SerializeField] private List<Cuttable> cuttables = null;

        public void Add(Cuttable cuttable) 
        {
            if (cuttables.Contains(cuttable)) { return; }

            cuttables.Add(cuttable);
        }

        public void CutAll() 
        {
            Clean();

            for (int i = 0; i < cuttables.Count; i++)
            {
                cuttables[i].Cut();
            }
        }

        private void Clean() 
        {
            for (int i = cuttables.Count - 1; i >= 0; i--)
            {
                if (cuttables[i] == null) { cuttables.RemoveAt(i); }
            }
        }
    }
}