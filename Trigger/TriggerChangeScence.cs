using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChangeScence : MonoBehaviour
{
    public GameObject Scence2_1;
    public GameObject Scence2_1_1;

    public GameObject Scence2_2_1_1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Scence2_1.SetActive(false);
            Scence2_1_1.SetActive(false);

            Scence2_2_1_1.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
