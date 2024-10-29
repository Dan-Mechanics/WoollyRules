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
        public bool IsHoveringRuleBrokenOnCut => isHoveringRuleBrokenOnCut;
        public event Action<bool, bool> OnHoverFeedback;
        public event Action<bool, Vector3> OnPoint;
        
        [Header("References")]

        [SerializeField] private Camera cam = null;
        //[SerializeField] private BlinkingText cutWarning = null;
        [SerializeField] private LayerMask cuttableMask = 0;
        //[SerializeField] private ScissorsCursor scissorsCursor = null;
        //[SerializeField] private ScissorsAnimator animator = null;
        [SerializeField] private UnityEvent onWarnRule = null;
        [SerializeField] private UnityEvent onCut = null;

        [Header("Settings")]

        [SerializeField] private float maxCutRange = 0f;
        [SerializeField] private KeyCode cutKey = KeyCode.None;

        [Header("Unity Events")]
        
        [Tooltip("FUTURE: this is bascialyl onGameEnd so mayne it should be on another script like gamemanager.cs for example ...")]
        [SerializeField] private UnityEvent onRuleBroken = null;

        private bool isHoveringRuleBrokenOnCut;

        private void Start()
        {
            Application.targetFrameRate = 300;
        }

        private void Update()
        {
            CheckInput();
        }

        private void FixedUpdate()
        {
            CheckIfHoveringSomething();
        }

        /// <summary>
        /// Called from ScissorsCursor.cs every update.
        /// </summary>
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

            if (cuttable.RuleBrokenOnCut) { onRuleBroken?.Invoke(); }
        }

        /// <summary>
        /// FUTURE: make a single-time event for when you mouseOver something basically because this spams it.
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
    }
}