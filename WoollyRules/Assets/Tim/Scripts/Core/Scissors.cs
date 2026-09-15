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
        [SerializeField] private Camera cam = null;
        [SerializeField] private LayerMask cuttableMask = 0;
        [SerializeField] private AudioSource cutSound = null;
        [SerializeField] private AudioClip cutClip = null;

        [Header("Settings")]
        [SerializeField] private float maxCutRange = 0f;
        [SerializeField] private KeyCode cutKey = KeyCode.None;
        [SerializeField] private float ruleBrokenCooldown = 0f;

        [Header("Unity Events")]
        [SerializeField] private UnityEvent onRuleBroken = null;
        [SerializeField] private UnityEvent onWarnRule = null;
        [SerializeField] private UnityEvent onCut = null;

        private float nextBreakRuleTime;
        private bool isWarning;

        private void Update()
        {
            if (Input.GetKeyDown(cutKey) && CastRay(out Cuttable cuttable, out RaycastHit hit))
                Cut(cuttable);
        }

        private void FixedUpdate()
            => CheckHovering();

        private bool CastRay(out Cuttable cuttable, out RaycastHit hit)
        {
            cuttable = null;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit, maxCutRange, cuttableMask, QueryTriggerInteraction.Ignore))
                return false;

            cuttable = hit.transform.GetComponent<Cuttable>();
            return cuttable;
        }

        public bool GetIsWarning()
            => isWarning;

        private void Cut(Cuttable cuttable) 
        {
            if (!cuttable.BlockCut)
                onCut?.Invoke();

            if (!cuttable.IsButton)
                cutSound.PlayOneShot(cutClip);

            cuttable.Cut();
            if (cuttable.RuleBrokenOnCut)
                BreakRule();
        }

        private void CheckHovering()
        {
            bool hasHit = CastRay(out Cuttable cuttable, out RaycastHit hit);
            OnPoint?.Invoke(hasHit, hit.point);
            if (!cuttable)
            {
                isWarning = false;
                OnHoverFeedback?.Invoke(false, false);
                return;
            }

            isWarning = cuttable.RuleBrokenOnCut;
            if (isWarning)
                onWarnRule?.Invoke();

            OnHoverFeedback?.Invoke(!cuttable.BlockHover, isWarning);
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