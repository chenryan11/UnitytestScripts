using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenUseOneTime : MonoBehaviour
{
    public DoorCloseUseOneTime close;

    public bool Opening = false;   //Is for saving the door state

    public bool hasOpenedCompletly = false;

    public bool front = false;
    public bool isLock = false;

    public float doorOpenAngle;

    public float smooth = 3f; //This the speed of the rotation

    private AudioSource audioSource;

    public AudioClip OpeningDoorSound;
    public AudioClip LockDoorSound;

    public GameObject DoorFront;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void ChangeDoorState()
    {
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
        audioSource.PlayOneShot(LockDoorSound);
    }

    void Update()
    {
        if (Opening)
        {
            if (front && hasOpenedCompletly == false) //front = true
            {
                Quaternion targetRotationOpen = Quaternion.Euler(0, doorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);

                transform.gameObject.layer = LayerMask.NameToLayer("Default");

                if (transform.localRotation == targetRotationOpen)
                {                    
                    transform.gameObject.tag = "DoorCloseUseOneTime";
                    hasOpenedCompletly = true;
                    close.hasCloseCompletly = false;
                    close.Closeing = false;
                    transform.gameObject.layer = LayerMask.NameToLayer("ineractable");
                }
            }        
        }
    }
}
