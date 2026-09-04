using UnityEngine;

namespace WoollyRules
{
    public class CameraRotator : MonoBehaviour
    {
        public enum InputMode { Keyboard, Cursor }
        [SerializeField] [Min(0f)] private float rotationSpeed = default;
        [SerializeField] private float movementMargin = default;
        [SerializeField] private InputMode inputMode = default;
        [SerializeField] private GameObject[] movementMarginsUI = default;

        private void Start()
        {
            for (int i = 0; i < movementMarginsUI.Length; i++)
            {
                movementMarginsUI[i].SetActive(inputMode == InputMode.Cursor);
            }
        }

        private void Update()
        {
            if (inputMode == InputMode.Keyboard)
            {
                Vector2 mov = new Vector2(-Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
                transform.Rotate(mov.x * rotationSpeed * Time.deltaTime * Vector3.forward, Space.Self);
                transform.Rotate(mov.y * rotationSpeed * Time.deltaTime * Vector3.right, Space.Self);
                return;
            }

            if (!Application.isFocused || Input.GetKey(KeyCode.Mouse1))
                return;

            if (Input.mousePosition.x <= movementMargin)
            {
                transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward, Space.World);
            }

            if (Input.mousePosition.x >= Screen.width - movementMargin)
            {
                transform.Rotate(-rotationSpeed * Time.deltaTime * Vector3.forward, Space.World);
            }
        }
    }

}