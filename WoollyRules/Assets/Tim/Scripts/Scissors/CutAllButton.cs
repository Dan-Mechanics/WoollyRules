using System;
using UnityEngine;

namespace WoollyRules
{
    public class CutAllButton : MonoBehaviour, ICuttable
    {
        public bool RuleBrokenOnCut => ruleBrokenOnCut;
        public bool Ignore => true;

        public event Action<ICuttable> OnCut;
        [SerializeField] private bool ruleBrokenOnCut = default;
        [SerializeField] private KeyCode[] keys = default;

        private void Update()
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (Input.GetKey(keys[i]))
                    Cut();
            }
        }

        public void Cut() 
        {
            MonoBehaviour[] monos = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
            for (int i = 0; i < monos.Length; i++)
            {
                if (monos[i].gameObject == gameObject)
                    continue;
                
                if (monos[i] is ICuttable cuttable)
                    OnCut?.Invoke(cuttable);
            }
        }
    }
}