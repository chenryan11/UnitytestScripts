using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningheadBackDoor : MonoBehaviour
{
    Ray ray; //射線

    float raylength = 4f;

    RaycastHit hit;

    public GameObject front2gless;
    public GameObject front3door;

    public TurningheadOperation_Table Operation_Table;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, raylength))
        {
            if (hit.collider.CompareTag ("TurningheadBackDoor"))
            {
                front2gless.SetActive(false);
                front3door.SetActive(true);

                enabled = false;

                Operation_Table.enabled = true;


                Destroy(GetComponent<TurningheadBackDoor>());
            }
        }
    }   
}
