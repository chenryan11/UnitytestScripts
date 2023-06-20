using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChangeScence3 : MonoBehaviour
{
    public GameObject noteandbox;
    public GameObject wall;

    private void Start()
    {
        noteandbox.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            noteandbox.SetActive(true);
            wall.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
