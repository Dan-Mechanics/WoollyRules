using System;
using UnityEngine;

namespace WoollyRules
{
    public class CutAllButton : MonoBehaviour
    {
        public event Action OnRuleBroken;
        [SerializeField] private KeyCode[] keys = default;

        private void Update()
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (Input.GetKey(keys[i]))
                    CutAll();
            }
        }

        public void CutAll() 
        {
            MonoBehaviour[] monos = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
            for (int i = 0; i < monos.Length; i++)
            {
                if (monos[i] is not ICuttable cuttable)
                    continue;

                cuttable.Cut();
                if (cuttable.RuleBrokenOnCut)
                    OnRuleBroken?.Invoke();
            }
        }
    }
}