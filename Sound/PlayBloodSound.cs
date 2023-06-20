using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBloodSound : MonoBehaviour
{
    public GameObject BloodSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        BloodSound.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            BloodSound.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        BloodSound.SetActive(false);
    }
}
