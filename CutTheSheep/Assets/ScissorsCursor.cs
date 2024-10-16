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
        }

        public Vector2 GetCursorPosition() { return cursorPosition; }
    }
}