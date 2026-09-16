using UnityEngine;
using UnityEngine.SceneManagement;

namespace WoollyRules
{
    public class SceneSwitcher : MonoBehaviour
    {
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
                return;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Switch("Menu");
        }

        public void Switch(string name)
            => SceneManager.LoadScene(name);
    }
}