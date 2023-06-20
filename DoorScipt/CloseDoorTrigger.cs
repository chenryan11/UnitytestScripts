using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorTrigger : MonoBehaviour
{
    public GameObject door;

    public DoorOpenUseOneTime door1;
    public DoorCloseUseOneTime door2;

    public float smooth = 3f;

    public float doorOpenAngle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(door.CompareTag("DoorOpenUseOneTime"))
            {
                door1.isLock = true;
            }
            else if(door.CompareTag("DoorCloseUseOneTime"))
            {
                door.GetComponent<DoorCloseUseOneTime>().ChangeDoorState();

                Destroy(gameObject);
            }
        }
    }
}
