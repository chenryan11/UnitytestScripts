using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2TriggerBGM : MonoBehaviour
{
    public GameObject BGM;

    void Start()
    {
        BGM.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BGM.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
