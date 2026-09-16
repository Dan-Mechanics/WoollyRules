using UnityEngine;

namespace WoollyRules
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int fps = default;
        private ScissorsAnimator scissorsAnimator;
        private ScissorsCursor scissorsCursor;
        private TextHighlight textHighlight;
        private CutAllButton cutAllButton;
        private ScissorsRotator rotator;
        private Scissors scissors;

        private void Awake()
        {
            scissors = FindAnyObjectByType<Scissors>(FindObjectsInactive.Include);
            textHighlight = FindAnyObjectByType<TextHighlight>(FindObjectsInactive.Include);
            rotator = FindAnyObjectByType<ScissorsRotator>(FindObjectsInactive.Include);
            scissorsCursor = FindAnyObjectByType<ScissorsCursor>(FindObjectsInactive.Include);
            scissorsAnimator = FindAnyObjectByType<ScissorsAnimator>(FindObjectsInactive.Include);
            cutAllButton = FindAnyObjectByType<CutAllButton>(FindObjectsInactive.Include);
            rotator = FindAnyObjectByType<ScissorsRotator>(FindObjectsInactive.Include);
        }

        private void Start()
        {
            Application.targetFrameRate = fps;
            scissors.OnPoint += rotator.PointTo;
            scissors.OnHoverFeedback += textHighlight.ChangeColor;
            scissors.OnHoverFeedback += scissorsAnimator.CheckIfShouldOpen;
            scissors.OnHoverFeedback += scissorsCursor.ChangeCursorSprite;
            cutAllButton.OnRuleBroken += scissors.BreakRule;
            rotator.GetIsWarning = scissors.GetIsWarning;
        }
    }
}
