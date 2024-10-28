using System;
using UnityEngine;
using UnityEngine.Events;

namespace WoollyRules
{
    /// <summary>
    /// FUTURE: could add layermask for raycast.
    /// NOTE: cursor is in build settings ez peazy.
    /// ADD: text rule. V
    /// ADD: rule reaction on different class then this script --> and that rule.cs class should be on the rules text maybe ??
    /// WARNING: NO CURSOR NO CUTTING !!
    /// </summary>
    public class Scissors : MonoBehaviour
    {
        public bool IsHoveringSheep => isHoveringOverSheep;
        public event Action<bool, bool> OnHoverFeedback;
        public event Action<bool, Vector3> OnPoint;
        
        [Header("References")]

        [SerializeField] private Camera cam = null;
        //[SerializeField] private BlinkingText cutWarning = null;
        [SerializeField] private LayerMask cuttableMask = 0;
        [SerializeField] private ScissorsCursor scissorsCursor = null;
        //[SerializeField] private ScissorsAnimator animator = null;
        [SerializeField] private UnityEvent onWarnRule = null;
        [SerializeField] private UnityEvent onCut = null;

        [Header("Settings")]

        [SerializeField] private float maxCutRange = 0f;
        [SerializeField] private KeyCode cutKey = KeyCode.None;

        [Header("Unity Events")]
        
        [Tooltip("FUTURE: this is bascialyl onGameEnd so mayne it should be on another script like gamemanager.cs for example ...")]
        [SerializeField] private UnityEvent onRuleBroken = null;

        private bool isHoveringOverSheep;

        /// <summary>
        /// Called from ScissorsCursor.cs every update.
        /// </summary>
        public void CheckInput()
        {
            if (Input.GetKeyDown(cutKey))
            {
                ICuttable cuttable = CheckCuttableCut();

                if (cuttable != null) { Cut(cuttable); }
            }
        }

        private ICuttable CheckCuttableHover(out RaycastHit hit, out bool hasHit)
        {
            Ray ray = cam.ScreenPointToRay(scissorsCursor.CursorPosition);

            hasHit = Physics.Raycast(ray, out hit, maxCutRange, cuttableMask, QueryTriggerInteraction.Ignore);

            if (hasHit) { return hit.transform.GetComponent<ICuttable>(); }

            return null;
        }

        private ICuttable CheckCuttableCut()
        {
            Ray ray = cam.ScreenPointToRay(scissorsCursor.CursorPosition);

            if (Physics.Raycast(ray, out RaycastHit hit, maxCutRange, cuttableMask, QueryTriggerInteraction.Ignore)) 
            {
                return hit.transform.GetComponent<ICuttable>();
            }

            return null;
        }

        private void Cut(ICuttable cuttable) 
        {
            onCut?.Invoke();

            cuttable.Cut();

            // does this work ??
            if (!((Cuttable)cuttable).IsSheep) 
            {
                // enable timer and webcam etc etc.

                onRuleBroken?.Invoke();
            }
        }

        private void FixedUpdate()
        {
            CheckIfHoveringSomething();
        }

        /// <summary>
        /// FUTURE: make a single-time event for when you mouseOver something basically because this spams it.
        /// </summary>
        private void CheckIfHoveringSomething()
        {
            ICuttable cuttable = CheckCuttableHover(out RaycastHit hit, out bool hasHit);

            OnPoint?.Invoke(hasHit, hit.point);

            if (cuttable != null)
            {
                // does this work ?
                isHoveringOverSheep = ((Cuttable)cuttable).IsSheep;

                if (!isHoveringOverSheep) { onWarnRule?.Invoke(); } // cutWarning.Warn();

                OnHoverFeedback?.Invoke(true, isHoveringOverSheep);
            }
            else 
            {
                isHoveringOverSheep = true;
                OnHoverFeedback?.Invoke(false, true);
            }
        }
    }
}