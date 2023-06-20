using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningheadBack3Gless : MonoBehaviour
{
    Ray ray; //射線

    float raylength = 4f;

    RaycastHit hit;

    public GameObject front1;
    public GameObject front2_gless;

    public TurningheadFront2Gless fron2gless;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, raylength))
        {
            if (hit.collider.CompareTag("TurningheadBack3Gless"))
            {
                front1.SetActive(false);
                front2_gless.SetActive(true);

                enabled = false;

                fron2gless.enabled = true;


                Destroy(GetComponent<TurningheadBack3Gless>());
            }
        }
    }
}
