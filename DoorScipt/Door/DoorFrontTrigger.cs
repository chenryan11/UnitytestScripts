using UnityEngine;

public class DoorFrontTrigger : MonoBehaviour
{
    public OpenDoor OpendoorR;
    public OpenDoor OpendoorL;

    public CloseDoor ClosedoorR;
    public CloseDoor ClosedoorL;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OpendoorR.front = true;
            OpendoorR.back = false;

            OpendoorL.front = true;
            OpendoorL.back = false;

            ClosedoorR.front = true;
            ClosedoorR.back = false;

            ClosedoorL.front = true;
            ClosedoorL.back = false;
        }
    }
}
