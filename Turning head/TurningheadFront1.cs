using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningheadFront1 : MonoBehaviour
{
    Ray ray; //射線

    float raylength = 4f;

    RaycastHit hit;

    public GameObject back2;
    public GameObject back3_gless;

    public TurningheadBack3Gless back3gless;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, raylength))
        {
            if (hit.collider.CompareTag("TurningheadFront1"))
            {
                back2.SetActive(false);
                back3_gless.SetActive(true);

                enabled = false;

                back3gless.enabled = true;


                Destroy(GetComponent<TurningheadFront1>());
            }
        }
    }
}
