using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    public GameObject BGM;
    public AudioClip sound;

    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {          
           // audioSource.clip = sound;

            BGM.GetComponent<AudioSource>().loop = true;

            BGM.GetComponent<AudioSource>().PlayOneShot(sound);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
