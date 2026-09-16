using UnityEngine;
using System.Collections;

namespace WoollyRules
{
    public class ScissorsAnimator : MonoBehaviour
    {
        [SerializeField] private Transform scissorsForward = default;
        [SerializeField] private Transform[] scissorParts = default;
        [SerializeField] private Transform[] scissorPartsOpen = default;
        [SerializeField] private Transform[] scissorPartsClosed = default;
        [SerializeField] private float cutLerpValue = default;
        [SerializeField] private float hoverLerpValue = default;
        [SerializeField] private float openScissorsAngle = default;
        [SerializeField] private float cutAnimationTime = default;
        private WaitForSeconds cutDelay;
        private bool isCutting;
        private bool isOpen;

        private void Awake()
            => cutDelay = new WaitForSeconds(cutAnimationTime);

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

        }

        public void CheckIfShouldOpen(bool isCuttable, bool ruleBrokenOnCut)
            => isOpen = isCuttable;

        private void FixedUpdate()
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, isCutting ? scissorsForward.localPosition : Vector3.zero, cutLerpValue);
            for (int i = 0; i < scissorParts.Length; i++)
            {
                if (!isCutting)
                {
                    scissorParts[i].localRotation = Quaternion.Lerp(
                        scissorParts[i].localRotation,
                        isOpen ? scissorPartsOpen[i].localRotation : scissorPartsClosed[i].localRotation,
                        hoverLerpValue);
                }
                else 
                {
                    scissorParts[i].localRotation = scissorPartsClosed[i].localRotation;
                }
            }
        }

        public void Cut() 
        {
            if (!isCutting)
                StartCoroutine(CutDelayed());
        }

        private IEnumerator CutDelayed() 
        {
            isCutting = true;
            yield return cutDelay;
            isCutting = false;
        }
    }
}