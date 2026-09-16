using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WoollyRules
{
    public class CutAllButton : MonoBehaviour
    {
        [Header("Make sure to add the non-sheep here, the one's present in scene by default.")]
        [SerializeField] private List<Cuttable> cuttables = default;
        [SerializeField] private KeyCode[] keys = default;
        [SerializeField] private bool alwaysBreakRule = default;
        [SerializeField] private bool callOnPressedButton = default;
        [SerializeField] private UnityEvent onPressButton = default;
        [SerializeField] private Scissors scissors = default;

        private void Update()
        {
            if (cuttables.Count <= 0)
                return;

            for (int i = 0; i < keys.Length; i++)
            {
                if (Input.GetKey(keys[i]))
                {
                    CutAll();
                    if (callOnPressedButton)
                        onPressButton?.Invoke();

                    if (alwaysBreakRule)
                        scissors.BreakRule();

                    return;
                }
            }
        }

        public void Add(Cuttable cuttable) 
        {
            if (!cuttables.Contains(cuttable))
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