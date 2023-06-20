using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlood : MonoBehaviour
{
    public GameObject Blood;
    public GameObject wall;
    public GameObject trigger3;

    private void Start()
    {
        Blood.SetActive(false);
        trigger3.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blood.SetActive(true);
            wall.SetActive(true);
            trigger3.SetActive(true);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
