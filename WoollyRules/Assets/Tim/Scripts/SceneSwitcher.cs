using UnityEngine;
using UnityEngine.SceneManagement;

namespace AppleAvalanche
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