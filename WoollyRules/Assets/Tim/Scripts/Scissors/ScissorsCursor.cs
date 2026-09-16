using UnityEngine;
using UnityEngine.UI;

namespace WoollyRules
{
    public class ScissorsCursor : MonoBehaviour
    {
        [SerializeField] private Scissors scissors = default;
        [SerializeField] private RectTransform rect = default;
        [SerializeField] private Image image = default;
        [SerializeField] private Sprite closedScissors = default;
        [SerializeField] private Sprite openScissors = default;

        private void Start()
        {
            Cursor.visible = false;
            ChangeCursorSprite(false, false);
            if (scissors)
                scissors.OnHoverFeedback += ChangeCursorSprite;
        }

        private void Update() 
            => PlaceCursor();

        private void PlaceCursor()
        {
            Vector2 cursorPosition = Input.mousePosition;
            cursorPosition.x -= Screen.width * 0.5f;
            cursorPosition.y -= Screen.height * 0.5f;

            rect.anchoredPosition = cursorPosition;
        }

        private void ChangeCursorSprite(bool isCuttable, bool ruleBrokenOnCut) 
        {
            if (image == null)
                return;

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