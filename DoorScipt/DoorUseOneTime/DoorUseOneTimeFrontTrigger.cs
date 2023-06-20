using UnityEngine;

public class DoorUseOneTimeFrontTrigger : MonoBehaviour
{
    public DoorOpenUseOneTime door;
    public DoorCloseUseOneTime door2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.front = true;
            door.isLock = false;
            door.hasOpenedCompletly = false;
           
            door2.front = true;
            door2.isLock = false;
        }
    }
}
