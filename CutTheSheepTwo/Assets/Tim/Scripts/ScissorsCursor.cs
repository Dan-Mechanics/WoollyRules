using UnityEngine;
using UnityEngine.UI;

namespace CutTheSheepTwo
{
    public class ScissorsCursor : MonoBehaviour
    {
        [SerializeField] private Scissors scissors = null;
        [SerializeField] private RectTransform rect = null;
        [SerializeField] private Image image = null;
        [SerializeField] private Sprite closedScissors = null;
        [SerializeField] private Sprite openScissors = null;

        public Vector2 CursorPosition => cursorPosition;
        private Vector2 cursorPosition;

        private void Start()
        {
            Application.targetFrameRate = 300;
            Cursor.visible = false;

            scissors.OnHoverFeedback += ChangeCursorColor;
        }

        private void Update()
        {
            PlaceCursor();

            scissors.CheckInput();
        }

        private void PlaceCursor()
        {
            cursorPosition = Input.mousePosition;
            cursorPosition.x -= Screen.width / 2f;
            cursorPosition.y -= Screen.height / 2f;

            rect.anchoredPosition = cursorPosition;

            cursorPosition = Input.mousePosition;
        }

        /// <summary>
        /// FUTURE: make the scissorcs sprite different / opening closing the scissors,
        /// and you could also have an indication in the scissors when ur not allowed to cut ( the bear for example ).
        /// </summary>
        private void ChangeCursorColor(bool hoveringOverSomething) 
        {
            if (image == null) { return; }

            image.sprite = hoveringOverSomething ? openScissors : closedScissors;
        }

        //public Vector2 GetCursorPosition() { return cursorPosition; }
    }
}