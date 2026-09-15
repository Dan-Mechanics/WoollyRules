using UnityEngine;

namespace WoollyRules
{
    public class GameManager : MonoBehaviour
    {
        private Scissors scissors;
        private ScissorsRotator rotator;

        private void Awake()
        {
            scissors = FindAnyObjectByType<Scissors>(FindObjectsInactive.Include);
            rotator = FindAnyObjectByType<ScissorsRotator>(FindObjectsInactive.Include);
        }

        private void Start()
        {
            Application.targetFrameRate = 300;
            scissors.OnPoint += rotator.PointTo;
            rotator.GetIsWarning = scissors.GetIsWarning;
        }
    }
}
