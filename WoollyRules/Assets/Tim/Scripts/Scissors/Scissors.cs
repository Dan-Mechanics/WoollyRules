using System;
using UnityEngine;
using UnityEngine.Events;

namespace WoollyRules
{
    public class Scissors : MonoBehaviour
    {
        public event Action<bool, bool> OnHoverFeedback;
        public event Action<bool, Vector3> OnPoint;
        
        [Header("References")]
        [SerializeField] private Camera cam = default;
        [SerializeField] private LayerMask cuttableMask = default;
        [SerializeField] private AudioSource cutSound = default;
        [SerializeField] private AudioClip cutClip = default;

        [Header("Settings")]
        [SerializeField] private float maxCutRange = default;
        [SerializeField] private KeyCode cutKey = default;
        [SerializeField] private float ruleBrokenCooldown = default;

        [Header("Unity Events")]
        [SerializeField] private UnityEvent onRuleBroken = default;
        [SerializeField] private UnityEvent onCut = default;
        private float nextBreakRuleTime;
        private bool isWarning;

        private void Update()
        {
            if (Input.GetKeyDown(cutKey) && CastRay(out ICuttable cuttable, out RaycastHit hit))
                Cut(cuttable);
        }

        private void FixedUpdate()
            => CheckHovering();

        private bool CastRay(out ICuttable cuttable, out RaycastHit hit)
        {
            cuttable = null;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit, maxCutRange, cuttableMask, QueryTriggerInteraction.Ignore))
                return false;

            cuttable = hit.transform.GetComponent<ICuttable>();
            return cuttable != null;
        }

        public bool GetIsWarning()
            => isWarning;

        public void Cut(ICuttable cuttable) 
        {
            if (cuttable.Ignore)
            {
                cuttable.Cut();
                return;
            }

            onCut?.Invoke();
            cutSound.PlayOneShot(cutClip);
            cuttable.Cut();
            if (cuttable.RuleBrokenOnCut)
                BreakRule();
        }

        private void CheckHovering()
        {
            bool hasHit = CastRay(out ICuttable cuttable, out RaycastHit hit);
            OnPoint?.Invoke(hasHit, hit.point);
            if (cuttable == null)
            {
                isWarning = false;
                OnHoverFeedback?.Invoke(false, false);
                return;
            }

            isWarning = cuttable.RuleBrokenOnCut;
            OnHoverFeedback?.Invoke(true, isWarning);
        }

        public void BreakRule()
        {
            if (Time.time < nextBreakRuleTime)
                return;

            onRuleBroken?.Invoke();
            nextBreakRuleTime = Time.time + ruleBrokenCooldown;
        }
    }
}