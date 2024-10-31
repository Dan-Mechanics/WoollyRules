using UnityEngine;
using UnityEngine.SceneManagement;

namespace AppleAvalanche
{
    public class SceneSwitcher : MonoBehaviour
    {
        public void Switch(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}