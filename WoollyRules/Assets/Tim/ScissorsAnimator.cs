using UnityEngine;
using System.Collections;

namespace WoollyRules
{
    /// <summary>
    /// TODO: add headers.
    /// </summary>
    public class ScissorsAnimator : MonoBehaviour
    {
        [SerializeField] private Scissors scissors = null;
        
        [SerializeField] private Transform scissorsVisual = null;
        [SerializeField] private Transform scissorsForward = null;

        [SerializeField] private Transform[] scissorParts = null;
        [SerializeField] private Transform[] scissorPartsOpen = null;
        [SerializeField] private Transform[] scissorPartsClosed = null;

        [SerializeField] private float cutLerpValue = 0f;
        [SerializeField] private float hoverLerpValue = 0f;
        [SerializeField] private float openScissorsAngle = 0f;

        [SerializeField] private float cutAnimationTime = 0f;

        private bool isOpen;
        private bool isCutting;

        private WaitForSeconds cutDelay;

        private void Awake()
        {
            cutDelay = new WaitForSeconds(cutAnimationTime);
        }

        private void Start()
        {
            if (scissorParts.Length != scissorPartsOpen.Length || scissorParts.Length != scissorPartsClosed.Length) 
            {
                Debug.LogError("if (scissorParts.Length != scissorPartsOpen.Length || scissorParts.Length != scissorPartsClosed.Length) !!");
                Destroy(gameObject);
            }

            for (int i = 0; i < scissorPartsOpen.Length; i++)
            {
                scissorPartsOpen[i].Rotate(Vector3.forward * openScissorsAngle, Space.Self);
            }

            scissors.OnHoverFeedback += CheckIfShouldOpen; ;
        }

        private void CheckIfShouldOpen(bool isCuttable, bool isSheep)
        {
            isOpen = isCuttable;
        }

        private void FixedUpdate()
        {
            //areScissorsOpen = Input.GetKey(KeyCode.Mouse1);
            //isDoingCutAnimation = Input.GetKey(KeyCode.Mouse0);

            scissorsVisual.localPosition = Vector3.Lerp(scissorsVisual.localPosition, isCutting ? scissorsForward.localPosition : Vector3.zero, cutLerpValue);
            
            for (int i = 0; i < scissorParts.Length; i++)
            {
                scissorParts[i].localRotation = Quaternion.Lerp(scissorParts[i].localRotation, isOpen ? scissorPartsOpen[i].localRotation : scissorPartsClosed[i].localRotation, hoverLerpValue);
            }
        }

        public void Cut() 
        {
            if (isCutting) { return; }

            StartCoroutine(CutCoroutine());
        }


        /// <summary>
        /// D.R.Y !!!
        /// </summary>
        private IEnumerator CutCoroutine() 
        {
            isCutting = true;

            yield return cutDelay;

            isCutting = false;
        }
    }
}