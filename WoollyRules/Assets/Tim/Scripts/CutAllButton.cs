using System.Collections.Generic;
using UnityEngine;

namespace WoollyRules
{
    public class CutAllButton : MonoBehaviour
    {
        [Header("Make sure to add the non-sheep here.")]
        [SerializeField] private List<Cuttable> cuttables = null;
        [SerializeField] private KeyCode wizardKey = KeyCode.None;

        private void Update()
        {
            if (wizardKey == KeyCode.None) { return; }

            if (Input.GetKey(wizardKey) && cuttables.Count > 0) 
            {
                CutAll();
            }
        }

        public void Add(Cuttable cuttable) 
        {
            if (cuttables.Contains(cuttable)) { return; }

            cuttables.Add(cuttable);
        }

        private void Clean() 
        {
            for (int i = cuttables.Count - 1; i >= 0; i--)
            {
                if (cuttables[i] == null) { cuttables.RemoveAt(i); }
            }
        }

        public void CutAll() 
        {
            Clean();

            for (int i = 0; i < cuttables.Count; i++)
            {
                cuttables[i].Cut();
            }

            cuttables.Clear();
        }

    }
}