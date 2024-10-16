using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CutTheSheep
{
    /// <summary>
    /// FUTURE: could add layermask for raycast.
    /// cursor is in build settings ez peazy.
    /// </summary>
    public class Scissors : MonoBehaviour
    {
        [SerializeField] private Camera cam = null;
        [SerializeField] private float maxCutRange = 0f;
        [SerializeField] private KeyCode cutKey = KeyCode.None;

        private void Update()
        {
            if (Input.GetKeyDown(cutKey))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, maxCutRange))
                {
                    StartCoroutine(ScaleMe(hit.transform));
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                }
            }
        }

        IEnumerator ScaleMe(Transform objTr)
        {
            objTr.localScale *= 1.2f;
            yield return new WaitForSeconds(0.5f);
            objTr.localScale /= 1.2f;
        }
    }
}