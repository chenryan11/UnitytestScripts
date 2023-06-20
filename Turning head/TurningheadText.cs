using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningheadText : MonoBehaviour
{
    Ray ray; //射線

    float raylength = 4f;

    RaycastHit hit;

    public GameObject picture;

    public TurningheadFront1 fron1;

    private void Start()
    {
        picture.SetActive(true);
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, raylength))
        {
            if (hit.collider.CompareTag("TurningheadText"))
            {
                picture.SetActive(false);

                enabled = false;

                fron1.enabled = true;


                Destroy(GetComponent<TurningheadText>());
            }
        }
    }
}
