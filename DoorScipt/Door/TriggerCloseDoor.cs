using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCloseDoor : MonoBehaviour
{
    public bool Closeing = false;

    public float doorCloseAngle;

    public float smooth = 3f; //This the speed of the rotation

    private AudioSource audioSource;

    public AudioClip ClosingDoorSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeDoorState()
    {
            Closeing = !Closeing; //open = true

            if (Closeing == true)
            {
                audioSource.PlayOneShot(ClosingDoorSound);
            }        
    }

    void Update()
    {
        if (Closeing)
        {
            Quaternion targetRotationOpen = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);
        }
    }
}
