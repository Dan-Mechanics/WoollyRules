using UnityEngine;

namespace WoollyRules 
{
    public class CameraRotator : MonoBehaviour
    {
        // [SerializeField] private ScissorsCursor cursor = null;
        [SerializeField] [Min(0f)] private float rotationSpeed = 0f;
        [SerializeField] private float movementMargin = 0f;
        [SerializeField] private bool wasd = false;

        [SerializeField] private GameObject[] movementMarginsUI = null;

        private void Start()
        {
            for (int i = 0; i < movementMarginsUI.Length; i++)
            {
                movementMarginsUI[i].SetActive(!wasd);
            }
        }

        private void Update()
        {
            if (wasd)
            {
                Vector2 mov = new Vector2(-Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
                
                transform.Rotate(mov.x * rotationSpeed * Time.deltaTime * Vector3.forward, Space.World);
                transform.Rotate(mov.y * rotationSpeed * Time.deltaTime * Vector3.right, Space.World);
            }
            else 
            {
                if (!Application.isFocused || Input.GetKey(KeyCode.Mouse1)) { return; }

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

}