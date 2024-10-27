using UnityEngine;
using UnityEngine.SceneManagement;

namespace AppleAvalanche
{
    /// <summary>
    /// Changes update rates.
    /// </summary>
    public class SceneSwitcher : MonoBehaviour
    {
        public void Switch(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}