using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChangeScence2 : MonoBehaviour
{
    public GameObject Scence2_2;

    public GameObject Scence2_2_1_1;

    public GameObject Trigger3;
    public GameObject TriggerBlood;

    public GameObject BGMTrigger2;

    private void Start()
    {
        BGMTrigger2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Scence2_2.SetActive(true);

            Scence2_2_1_1.SetActive(false);

            Trigger3.SetActive(true);
            TriggerBlood.SetActive(true);

            BGMTrigger2.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
