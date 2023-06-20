using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFalseS2ToS3 : MonoBehaviour
{
    public GameObject S2ToS3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            S2ToS3.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
