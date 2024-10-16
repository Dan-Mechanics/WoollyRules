using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CutTheSheep
{
    public class Scisscors : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                // cache
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


                if (Physics.Raycast(ray, out hit, 100f))
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