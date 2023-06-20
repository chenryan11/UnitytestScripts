using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoorFrontTrigger : MonoBehaviour
{ 
    public LockDoor LockdoorR;
    public LockDoor LockdoorL;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LockdoorR.front = true;
            LockdoorL.front = true;
        }
    }
}
