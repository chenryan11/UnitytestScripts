using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloseUseOneTime : MonoBehaviour
{
    public DoorOpenUseOneTime open;

    public bool Closeing = false;   //Is for saving the door state

    public bool hasCloseCompletly = false;


    public bool front = false;
    public bool isLock = false;

    public float doorCloseAngle;

    public float smooth = 3f; //This the speed of the rotation

    private AudioSource audioSource;

    public AudioClip ClosingDoorSound;
    public AudioClip LockDoorSound;

    public GameObject DoorFront;

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
                Quaternion targetRotationOpen = Quaternion.Euler(0, doorCloseAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);

                transform.gameObject.layer = LayerMask.NameToLayer("Default");

                if (transform.localRotation == targetRotationOpen)
                {
                    front = false;
                    open.isLock = true;
                    open.Opening = false;
                    hasCloseCompletly = true;
                    transform.gameObject.tag = "DoorOpenUseOneTime";
                    transform.gameObject.layer = LayerMask.NameToLayer("ineractable");
                }
            }
        }
    }
}
