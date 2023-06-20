using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningheadFront2Gless : MonoBehaviour
{
    Ray ray; //射線

    float raylength = 4f;

    RaycastHit hit;
    public GameObject bakc4;

    public TurningheadBackDoor backdoor;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, raylength))
        {
            if (hit.collider.CompareTag("TurningheadFront2Gless"))
            { 
                bakc4.SetActive(true);

                enabled = false;

                backdoor.enabled = true;


                Destroy(GetComponent<TurningheadFront2Gless>());
            }
        }
    }
}
