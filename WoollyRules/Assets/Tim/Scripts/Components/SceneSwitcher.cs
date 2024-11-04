using UnityEngine;
using UnityEngine.SceneManagement;

namespace WoollyRules.Components
{
    public class SceneSwitcher : MonoBehaviour
    {
        private void Start()
        {
            Application.targetFrameRate = 300;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                Switch("Menu");
            }
        }

        public void Switch(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}