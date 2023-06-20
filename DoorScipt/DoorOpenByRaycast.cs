using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenByRaycast : MonoBehaviour
{
    public bool Opening = false;   //Is for saving the door state

    public bool hasOpenedCompletly = false;

    public bool isLock = false;

    public float doorOpenAngle;

    public float smooth = 3f; //This the speed of the rotation

    private AudioSource audioSource;

    public AudioClip OpeningDoorSound;
    //public AudioClip LockDoorSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void ChangeDoorState()
    {
        hasOpenedCompletly = false;
        if (isLock != true)
        {
            Opening = !Opening; //open = true


            if (Opening == true)
            {
                audioSource.PlayOneShot(OpeningDoorSound);
            }
        }
        else
        {
            PlayLockDoorSound();
        }
    }

    public void PlayLockDoorSound()
    {
       // audioSource.PlayOneShot(LockDoorSound);
        transform.gameObject.tag = "Doorislockneedkey";
    }

    void Update()
    {
        if (Opening)
        {
            if (hasOpenedCompletly == false)
            {
                Quaternion targetRotationOpen = Quaternion.Euler(0, -doorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);

                if (transform.localRotation == targetRotationOpen)
                {
                    //transform.gameObject.tag = "CloseDoor";
                    hasOpenedCompletly = true;

                }
            }          
        }
    }
}
