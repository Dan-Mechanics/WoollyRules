using System;
using UnityEngine;
using UnityEngine.Events;

namespace WoollyRules
{
    public class Scissors : MonoBehaviour
    {
        public bool IsHoveringRuleBrokenOnCut => isHoveringRuleBrokenOnCut;
        public event Action<bool, bool> OnHoverFeedback;
        public event Action<bool, Vector3> OnPoint;
        
        [Header("References")]

        [SerializeField] private Camera cam = null;
        [SerializeField] private LayerMask cuttableMask = 0;

        [Header("Settings")]

        [SerializeField] private float maxCutRange = 0f;
        [SerializeField] private KeyCode cutKey = KeyCode.None;
        [SerializeField] private float ruleBrokenCooldown = 0f;

        [Header("Unity Events")]
        
        [SerializeField] private UnityEvent onRuleBroken = null;
        [SerializeField] private UnityEvent onWarnRule = null;
        [SerializeField] private UnityEvent onCut = null;

        private bool isHoveringRuleBrokenOnCut;
        private float nextCanBreakRuleTime;

        private void Update()
        {
            CheckInput();
        }

        private void FixedUpdate()
        {
            CheckIfHoveringSomething();
        }

        private void CheckInput()
        {
            if (Input.GetKeyDown(cutKey))
            {
                Cuttable cuttable = CheckCuttable();

                if (cuttable != null) { Cut(cuttable); }
            }
        }

        private Cuttable CheckCuttableHovering(out RaycastHit hit, out bool hasHit)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            hasHit = Physics.Raycast(ray, out hit, maxCutRange, cuttableMask, QueryTriggerInteraction.Ignore);

            if (hasHit) { return hit.transform.GetComponent<Cuttable>(); }

            return null;
        }

        private Cuttable CheckCuttable()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, maxCutRange, cuttableMask, QueryTriggerInteraction.Ignore)) 
            {
                return hit.transform.GetComponent<Cuttable>();
            }

            return null;
        }

        private void Cut(Cuttable cuttable) 
        {
            if (!cuttable.BlockCut) { onCut?.Invoke(); }

            cuttable.Cut();

            if (cuttable.RuleBrokenOnCut) { BreakRule(); }
        }

        /// <summary>
        /// IDEA: could make a single-time event for when you mouseOver something basically because this spams it.
        /// </summary>
        private void CheckIfHoveringSomething()
        {
            Cuttable cuttable = CheckCuttableHovering(out RaycastHit hit, out bool hasHit);

            OnPoint?.Invoke(hasHit, hit.point);

            if (cuttable != null)
            {
                isHoveringRuleBrokenOnCut = cuttable.RuleBrokenOnCut;

                if (isHoveringRuleBrokenOnCut) { onWarnRule?.Invoke(); } // cutWarning.Warn();

                OnHoverFeedback?.Invoke(!cuttable.BlockHover, isHoveringRuleBrokenOnCut);
            }
            else 
            {
                isHoveringRuleBrokenOnCut = false;
                OnHoverFeedback?.Invoke(false, false);
            }
        }

        public void BreakRule()
        {
            if (Time.time < nextCanBreakRuleTime) { return; }
            
            onRuleBroken?.Invoke();

            nextCanBreakRuleTime = Time.time + ruleBrokenCooldown;
        }
    }
}