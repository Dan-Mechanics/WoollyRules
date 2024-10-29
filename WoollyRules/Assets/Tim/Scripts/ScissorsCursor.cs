using UnityEngine;
using UnityEngine.UI;

namespace WoollyRules
{
    public class ScissorsCursor : MonoBehaviour
    {
        public Vector2 CursorPosition => cursorPosition;

        [SerializeField] private Scissors scissors = null;
        [SerializeField] private RectTransform rect = null;
        [SerializeField] private Image image = null;
        [SerializeField] private Sprite closedScissors = null;
        [SerializeField] private Sprite openScissors = null;

        private Vector2 cursorPosition;

        private void Start()
        {
            Application.targetFrameRate = 300;
            Cursor.visible = false;

            scissors.OnHoverFeedback += ChangeCursorSprite;
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
        /// TODO: have an indication in the scissors when ur not allowed to cut ( the bear for example ). VVV
        /// </summary>
        private void ChangeCursorSprite(bool isCuttable, bool ruleBrokenOnCut) 
        {
            // if we destroy image when closing game then this might throw an error thats why this is here.
            if (image == null) { return; }

            image.sprite = isCuttable ? openScissors : closedScissors;
            image.color = ruleBrokenOnCut ? Color.red : Color.white;
        }

        public void ShowNormalCursor() 
        {
            Cursor.visible = true;
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}