using System.Collections.Generic;
using UnityEngine;

namespace WoollyRules.Core
{
    public class CutAllButton : MonoBehaviour
    {
        [Header("Make sure to add the non-sheep here, the one's present in scene by default.")]
        [SerializeField] private List<Cuttable> cuttables = null;
        [SerializeField] private KeyCode[] keys = null;

        private void Update()
        {
            //if (keys.Length <= 0) { return; }
            if(cuttables.Count <= 0) { return; }

            for (int i = 0; i < keys.Length; i++)
            {
                if (Input.GetKey(keys[i]))
                {
                    CutAll();

                    return;
                }
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