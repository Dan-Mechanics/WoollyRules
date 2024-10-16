using UnityEngine;

namespace CutTheSheep
{
    /// <summary>
    /// FUTURE: could add layermask for raycast.
    /// cursor is in build settings ez peazy.
    /// ADD: text rule.
    /// </summary>
    public class Scissors : MonoBehaviour
    {
        [Header("References")]

        [SerializeField] private Camera cam = null;
        [SerializeField] private CutWarning cutWarning = null;

        [Header("Settings")]

        [SerializeField] private float maxCutRange = 0f;
        [SerializeField] private KeyCode cutKey = KeyCode.None;

        private void Start()
        {
            Application.targetFrameRate = 300;
        }

        private void Update()
        {
            // TODO: fix this.
            if (Input.GetKeyDown(cutKey))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, maxCutRange))
                {
                    print($"we hit: {hit.transform.name}.");

                    // if there is something to cut we cut it.
                    Cuttable cuttable = hit.transform.GetComponent<Cuttable>();
                    if (cuttable != null) { cuttable.Cut(); }
                }
            }
        }

        private void FixedUpdate()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, maxCutRange))
            {
                Cuttable cuttable = hit.transform.GetComponent<Cuttable>();
                if (cuttable != null && !cuttable.GetIsSheep()) { cutWarning.Warn(); }
            }
        }
    }
}