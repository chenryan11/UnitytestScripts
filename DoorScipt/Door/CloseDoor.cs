using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public OpenDoor open;

    public bool Closeing = false;   //Is for saving the door state

    public bool hasCloseCompletly = false;


    public bool front = false;
    public bool back = false;
    public bool isLock = false;

    public float doorCloseAngle;

    public float smooth = 3f; //This the speed of the rotation

    private AudioSource audioSource;

    public AudioClip ClosingDoorSound;
    public AudioClip LockDoorSound;

    public GameObject DoorFront;
    public GameObject DoorBack;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void ChangeDoorState()
    {
        hasCloseCompletly = false;
        if (isLock != true)
        {
            Closeing = !Closeing; //open = true

            if (Closeing == true)
            {
                audioSource.PlayOneShot(ClosingDoorSound);
            }
        }
    }

    void PlayLockDoorSound()
    {
        audioSource.PlayOneShot(LockDoorSound);
    }

    void Update()
    {
        if (Closeing)
        {
            if (front && hasCloseCompletly == false) //front = true
            {
                Quaternion targetRotationOpen = Quaternion.Euler(0, -doorCloseAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);

                DoorBack.SetActive(false);
                transform.gameObject.layer = LayerMask.NameToLayer("Default");

                if (transform.localRotation == targetRotationOpen)
                {
                    DoorBack.SetActive(true);              
                    front = false;
                    hasCloseCompletly = true;
                    transform.gameObject.tag = "OpenDoor";
                    Closeing = false;
                    transform.gameObject.layer = LayerMask.NameToLayer("ineractable");
                }
            }

            if (back && hasCloseCompletly == false) //Back =true
            {
                Quaternion targetRotationOpen = Quaternion.Euler(0, doorCloseAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);

                DoorFront.SetActive(false);
                transform.gameObject.layer = LayerMask.NameToLayer("Default");

                if (transform.localRotation == targetRotationOpen)
                {
                    DoorFront.SetActive(true);
                    back = false;                    
                    hasCloseCompletly = true;
                    transform.gameObject.tag = "OpenDoor";
                    Closeing = false;
                    transform.gameObject.layer = LayerMask.NameToLayer("ineractable");
                }
            }
        }
    }
}
