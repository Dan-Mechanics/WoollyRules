using UnityEngine;
using UnityEngine.UI;

namespace CutTheSheep
{
    public class ScissorsCursor : MonoBehaviour
    {
        [SerializeField] private Scissors scissors = null;
        [SerializeField] private RectTransform rect = null;
        [SerializeField] private Image image = null;
        
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
            // HOTFIX: if we destroy it we cant change the color of course.
            if (image == null) { return; }
            
            image.color = hoveringOverSomething ? Color.yellow : Color.black;
            image.transform.localScale = Vector3.one * (hoveringOverSomething ? 1f : 1.5f);
        }

        public Vector2 GetCursorPosition() { return cursorPosition; }
    }
}