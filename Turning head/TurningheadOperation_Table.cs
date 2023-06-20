using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningheadOperation_Table : MonoBehaviour
{
    Ray ray; //射線

    float raylength = 4f;

    RaycastHit hit;

    public GameObject BackScenes;
    public GameObject sence2_2;


    private void Start()
    {
        BackScenes.SetActive(true);
        sence2_2.SetActive(false);
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, raylength))
        {
            if (hit.collider.CompareTag("Operation_Table"))
            {
                BackScenes.SetActive(false);

                enabled = false;

                GetComponent<AudioSource>().enabled = false;

                sence2_2.SetActive(true);


                Destroy(GetComponent<TurningheadOperation_Table>());
            }
        }
    }
}
