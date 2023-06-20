using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorText : MonoBehaviour
{
    private Animator _animator;

    public bool Open = false;
    public bool Close = false;

    public bool front = false;

    private AudioSource audioSource;

    public AudioClip OpeningDoorSound;
    public AudioClip ClosingDoorSound;
    public AudioClip LockDoorSound;

    public bool isLock = false;

    private void Start()
    {
        Close = true;
        audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    public void ChangeDoorState()
    {
        Close = false;
        Open = !Open; //open = true

        if (Open == true)
        {
            //Invoke("CloseDoor", 5);
            audioSource.PlayOneShot(OpeningDoorSound);
            _animator.SetTrigger("OpenDoor");
            _animator.SetTrigger("out");
        }

    }

     void CloseDoor()
     {
       
    }

    public void Stop()
    {
        _animator.enabled = false;
    }

   /* private void Update()
    {
        if(Open)
        {
            _animator.SetTrigger("OpenDoor");
            Open = false;
        }
        if(Close)
        {
            _animator.SetTrigger("CloseDoor");
        }
    }*/
}
