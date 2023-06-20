using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public CloseDoor close;

    public bool Opening = false;   //Is for saving the door state

    public bool hasOpenedCompletly = false;

    public bool front = false;
    public bool back = false;
    public bool isLock = false;

    public float doorOpenAngle;

    public float smooth = 3f; //This the speed of the rotation

    private AudioSource audioSource;

    public AudioClip OpeningDoorSound;
    public AudioClip LockDoorSound;

    public GameObject DoorFront;
    public GameObject DoorBack;

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
        audioSource.PlayOneShot(LockDoorSound);
        transform.gameObject.tag = "Doorislockneedkey";
    }

    void Update()
    {
        if (Opening)
        {
            if (front && hasOpenedCompletly == false) //front = true
            {
                //close.hasCloseCompletly = false;

                Quaternion targetRotationOpen = Quaternion.Euler(0, -doorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);

                DoorBack.SetActive(false);
                transform.gameObject.layer = LayerMask.NameToLayer("Default");

                if (transform.localRotation == targetRotationOpen)
                {
                    DoorBack.SetActive(true);
                    front = false;
                    transform.gameObject.tag = "CloseDoor";
                    hasOpenedCompletly = true;
                    Opening = false;
                    transform.gameObject.layer = LayerMask.NameToLayer("ineractable");
                }
            }

            if (back && hasOpenedCompletly == false) //Back =true
            {
                //close.hasCloseCompletly = false;

                Quaternion targetRotationOpen = Quaternion.Euler(0, doorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);

                DoorFront.SetActive(false);
                transform.gameObject.layer = LayerMask.NameToLayer("Default");

                if (transform.localRotation == targetRotationOpen)
                {
                    DoorFront.SetActive(true);
                    back = false;
                    transform.gameObject.tag = "CloseDoor";
                    hasOpenedCompletly = true;
                    Opening = false;
                    transform.gameObject.layer = LayerMask.NameToLayer("ineractable");
                }
            }
        }
    }
}
