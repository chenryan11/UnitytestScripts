using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopScareSound : MonoBehaviour
{
    public GameObject stopScareSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            stopScareSound.SetActive(false);
        }
    }
}
