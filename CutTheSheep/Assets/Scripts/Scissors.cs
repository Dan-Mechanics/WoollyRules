using System;
using UnityEngine;
using UnityEngine.Events;

namespace CutTheSheep
{
    /// <summary>
    /// FUTURE: could add layermask for raycast.
    /// NOTE: cursor is in build settings ez peazy.
    /// ADD: text rule. V
    /// ADD: rule reaction on different class then this script --> and that rule.cs class should be on the rules text maybe ??
    /// TODO: order scene and make environment etc.
    /// WARNING: NO CURSOR NO CUTTING !!
    /// </summary>
    public class Scissors : MonoBehaviour
    {
        public event Action<bool> OnHoverFeedback;
        
        [Header("References")]

        [SerializeField] private Camera cam = null;
        [SerializeField] private CutWarning cutWarning = null;
        [SerializeField] private LayerMask cuttableMask = 0;
        [SerializeField] private ScissorsCursor scissorsCursor = null;

        [Header("Settings")]

        [SerializeField] private float maxCutRange = 0f;
        [SerializeField] private KeyCode cutKey = KeyCode.None;

        [Header("Unity Events")]
        
        [Tooltip("FUTURE: this is bascialyl onGameEnd so mayne it should be on another script like gamemanager.cs for example ...")]
        [SerializeField] private UnityEvent onRuleBroken = null;

        /// <summary>
        /// Called from ScissorsCursor.cs every update.
        /// </summary>
        public void CheckInput()
        {
            if (Input.GetKeyDown(cutKey))
            {
                Cuttable cuttable = CheckCuttable();

                if (cuttable != null) { Cut(cuttable); }
            }
        }

        private Cuttable CheckCuttable()
        {
            Ray ray = cam.ScreenPointToRay(scissorsCursor.GetCursorPosition());

            if (Physics.Raycast(ray, out RaycastHit hit, maxCutRange, cuttableMask, QueryTriggerInteraction.Ignore))
            {
                // print($"we hit: {hit.transform.name}.");

                return hit.transform.GetComponent<Cuttable>();
            }

            return null;
        }

        /*private void PlaceCursor()
        {
            cursorPosition = Input.mousePosition;
            cursorPosition.x -= Screen.width / 2f;
            cursorPosition.y -= Screen.height / 2f;

            cursorImage.anchoredPosition = cursorPosition;
        }*/

        private void Cut(Cuttable cuttable) 
        {
            cuttable.Cut();

            if (!cuttable.GetIsSheep()) 
            {
                // enable timer and webcam.

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
            Cuttable cuttable = CheckCuttable();

            OnHoverFeedback?.Invoke(cuttable != null);

            if (cuttable != null && !cuttable.GetIsSheep()) { cutWarning.Warn(); }
        }
    }
}