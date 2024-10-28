using UnityEngine;

namespace WoollyRules
{
    public class ScissorsAnimator : MonoBehaviour
    {
        [SerializeField] private Transform scissors = null;

        [SerializeField] private Transform scissorsForward = null;
        [SerializeField] private Transform scissorsBackward = null;

        [SerializeField] private Transform[] scissorParts = null;

        [SerializeField] private Transform[] scissorPartsOpen = null;
        [SerializeField] private Transform[] scissorPartsClosed = null;

        [SerializeField] private float forwardScissorsForwardAmount = 0f;

        [SerializeField] private float cutLerpValue = 0f;
        [SerializeField] private float hoverLerpValue = 0f;

        [SerializeField] private Transform forward_ = null;

        public bool open;
        public bool forward;

        private void Start()
        {
            if (scissorParts.Length != scissorPartsOpen.Length || scissorParts.Length != scissorPartsClosed.Length) 
            {
                Debug.LogError("if (scissorParts.Length != scissorPartsOpen.Length || scissorParts.Length != scissorPartsClosed.Length) !!");
                Destroy(gameObject);
            }
        }

        private void FixedUpdate()
        {
            open = Input.GetKey(KeyCode.Mouse1);
            forward = Input.GetKey(KeyCode.Mouse0);

            scissorsForward.forward = scissors.forward;
            scissorsForward.localPosition = scissorsBackward.localPosition + scissorsForward.forward * forwardScissorsForwardAmount;

            scissors.localPosition = Vector3.Lerp(scissors.localPosition, forward ? scissorsForward.localPosition : scissorsBackward.localPosition, cutLerpValue);
            
            for (int i = 0; i < scissorParts.Length; i++)
            {
                scissorParts[i].localRotation = Quaternion.Lerp(scissorParts[i].localRotation, open ? scissorPartsOpen[i].localRotation : scissorPartsClosed[i].localRotation, hoverLerpValue);
            }
        }

    }
}