using UnityEngine;

public class DoorBackTrigger : MonoBehaviour
{
    public OpenDoor OpendoorR;
    public OpenDoor OpendoorL;

    public CloseDoor ClosedoorR;
    public CloseDoor ClosedoorL;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OpendoorR.front = false;
            OpendoorR.back = true;

            OpendoorL.front = false;
            OpendoorL.back = true;

            ClosedoorR.front = false;
            ClosedoorR.back = true;

            ClosedoorL.front = false;
            ClosedoorL.back = true;
        }
    }
}
