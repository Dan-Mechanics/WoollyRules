using UnityEngine;

namespace WoollyRules
{
    public class CameraRotator : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float rotationSpeed = default;

        private void Update()
        {
            Vector2 mov = new Vector2(-Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            transform.Rotate(mov.x * rotationSpeed * Time.deltaTime * Vector3.forward, Space.Self);
            transform.Rotate(mov.y * rotationSpeed * Time.deltaTime * Vector3.right, Space.Self);
        }
    }
}