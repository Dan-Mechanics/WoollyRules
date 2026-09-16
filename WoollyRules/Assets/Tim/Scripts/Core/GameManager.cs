using UnityEngine;

namespace WoollyRules
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int fps = default;
        private Scissors scissors;
        private ScissorsRotator rotator;

        private void Awake()
        {
            scissors = FindAnyObjectByType<Scissors>(FindObjectsInactive.Include);
            rotator = FindAnyObjectByType<ScissorsRotator>(FindObjectsInactive.Include);
        }

        private void Start()
        {
            Application.targetFrameRate = fps;
            scissors.OnPoint += rotator.PointTo;
            rotator.GetIsWarning = scissors.GetIsWarning;
        }
    }
}
