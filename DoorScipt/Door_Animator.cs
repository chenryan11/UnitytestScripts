using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Animator : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
           // _animator.SetBool("open", true);
            _animator.SetTrigger("OpenDoor");
    }
    void OnTriggerExit(Collider other)
    {
        _animator.enabled = true;
    }


}
