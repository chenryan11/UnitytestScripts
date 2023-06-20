using UnityEngine;

public class TurningheadDoorOpen : MonoBehaviour
{
    Ray ray; //射線

    float raylength = 1.5f; 

    RaycastHit hit; 

    public GameObject DoorClose;

    public float doorOpenAngle;
    public float smooth = 3f;

    public DoorCloseUseOneTime door;
    public DoorOpenByRaycast dooropen;

    public TurningheadCloseLight CloseLight_On;

    private void Start()
    {
        CloseLight_On.enabled = false;
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, raylength))           
        {             
            if (hit.collider.CompareTag("TurningheadDoorOpen"))
            {
                dooropen.GetComponent<DoorOpenByRaycast>().ChangeDoorState();

                DoorClose.GetComponent<AudioSource>().enabled = false;
               door.GetComponent<DoorCloseUseOneTime>().ChangeDoorState();
               door.Closeing = true;

                CloseLight_On.enabled = true;

                enabled = false;

                Destroy(GetComponent<TurningheadDoorOpen>());
            }          
        }       
    }
}
