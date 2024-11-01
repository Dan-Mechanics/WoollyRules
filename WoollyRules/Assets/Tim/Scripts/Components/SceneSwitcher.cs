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

        public void Switch(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}