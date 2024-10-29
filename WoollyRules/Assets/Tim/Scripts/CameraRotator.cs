using UnityEngine;

namespace WoollyRules 
{
    public class CameraRotator : MonoBehaviour
    {
        // [SerializeField] private ScissorsCursor cursor = null;
        [SerializeField] [Min(0f)] private float rotationSpeed = 0f;
        [SerializeField] private float movementMargin = 0f;

        private void Update()
        {
            if (!Application.isFocused) { return; }
            // ??
            if (Input.GetKey(KeyCode.Mouse1)) { return; }

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