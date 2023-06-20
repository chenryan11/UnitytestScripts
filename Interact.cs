using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public GameObject PauseUIMune;

    public string interactButton;

    public float interactDistance = 1.5f;
    public LayerMask interactLayer; //filter

    public GameObject interactIcon;

    public GameObject Press_OpenDoor;
    public GameObject Press_CloseDoor;

    public GameObject Doorislock;
    public GameObject Doorislockneedkey;

    public GameObject Press_PickUpNote;
    public GameObject Press_PickUpKey;

    public GameObject Press_Exit;

    public bool isInteracting;

    private void Start()
    {
        PauseUIMune.GetComponent<PauseUI>().enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (interactIcon != null)
        {
            interactIcon.SetActive(false);

            Press_OpenDoor.SetActive(false);
            Press_CloseDoor.SetActive(false);

            Doorislock.SetActive(false);
            Doorislockneedkey.SetActive(false);

            Press_PickUpNote.SetActive(false);
            Press_PickUpKey.SetActive(false);

            Press_Exit.SetActive(false);
        }
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        //shoots a ray
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            //Check if we are not interacting
            if (isInteracting == false)
            {
                if (interactIcon != null)
                {
                    interactIcon.SetActive(true);

                    if (hit.collider.CompareTag("OpenDoor"))
                    {
                        Press_OpenDoor.SetActive(true);
                        Press_CloseDoor.SetActive(false);

                        Doorislock.SetActive(false);
                        Doorislockneedkey.SetActive(false);

                        Press_PickUpNote.SetActive(false);
                        Press_PickUpKey.SetActive(false);

                        Press_Exit.SetActive(false);
                    }
                    else if (hit.collider.CompareTag("CloseDoor"))
                    {
                        Press_OpenDoor.SetActive(false);
                        Press_CloseDoor.SetActive(true);

                        Doorislock.SetActive(false);
                        Doorislockneedkey.SetActive(false);

                        Press_PickUpNote.SetActive(false);
                        Press_PickUpKey.SetActive(false);

                        Press_Exit.SetActive(false);
                    }

                    else if (hit.collider.CompareTag("DoorOpenUseOneTime"))
                    {
                        Press_OpenDoor.SetActive(true);
                        Press_CloseDoor.SetActive(false);

                        Doorislock.SetActive(false);
                        Doorislockneedkey.SetActive(false);

                        Press_PickUpNote.SetActive(false);
                        Press_PickUpKey.SetActive(false);

                        Press_Exit.SetActive(false);
                    }
                    else if (hit.collider.CompareTag("DoorCloseUseOneTime"))
                    {
                        Press_OpenDoor.SetActive(false);
                        Press_CloseDoor.SetActive(true);

                        Doorislock.SetActive(false);
                        Doorislockneedkey.SetActive(false);

                        Press_PickUpNote.SetActive(false);
                        Press_PickUpKey.SetActive(false);

                        Press_Exit.SetActive(false);
                    }

                    else if (hit.collider.CompareTag("LockDoor"))
                    {
                        Press_OpenDoor.SetActive(false);
                        Press_CloseDoor.SetActive(false);

                        Doorislock.SetActive(true);
                        Doorislockneedkey.SetActive(false);

                        Press_PickUpNote.SetActive(false);
                        Press_PickUpKey.SetActive(false);

                        Press_Exit.SetActive(false);
                    }

                    else if (hit.collider.CompareTag("Doorislockneedkey"))
                    {
                        Press_OpenDoor.SetActive(false);
                        Press_CloseDoor.SetActive(false);

                        Doorislock.SetActive(false);
                        Doorislockneedkey.SetActive(true);

                        Press_PickUpNote.SetActive(false);
                        Press_PickUpKey.SetActive(false);

                        Press_Exit.SetActive(false);
                    }

                    else if (hit.collider.CompareTag("Note") || hit.collider.CompareTag("NoteGoToScence") || hit.collider.CompareTag("NoteGoToScenc2") || hit.collider.CompareTag("NoteChangScenes") || hit.collider.CompareTag("NoteChangeScence2") || hit.collider.CompareTag("NoteToFinal"))
                    {                       
                        Press_OpenDoor.SetActive(false);
                        Press_CloseDoor.SetActive(false);

                        Doorislock.SetActive(false);
                        Doorislockneedkey.SetActive(false);

                        Press_PickUpNote.SetActive(true);
                        Press_PickUpKey.SetActive(false);

                        Press_Exit.SetActive(false);
                    }

                    else if (hit.collider.CompareTag("Key"))
                    {
                        Press_OpenDoor.SetActive(false);
                        Press_CloseDoor.SetActive(false);

                        Doorislock.SetActive(false);
                        Doorislockneedkey.SetActive(false);

                        Press_PickUpNote.SetActive(false);
                        Press_PickUpKey.SetActive(true);

                        Press_Exit.SetActive(false);
                    }

                    else if (hit.collider.CompareTag("Final"))
                    {
                        Press_OpenDoor.SetActive(false);
                        Press_CloseDoor.SetActive(false);

                        Doorislock.SetActive(false);
                        Doorislockneedkey.SetActive(false);

                        Press_PickUpNote.SetActive(false);
                        Press_PickUpKey.SetActive(false);

                        Press_Exit.SetActive(true);
                    }

                    else
                    {
                        Press_OpenDoor.SetActive(false);
                        Press_CloseDoor.SetActive(false);

                        Doorislock.SetActive(false);
                        Doorislockneedkey.SetActive(false);

                        Press_PickUpNote.SetActive(false);
                        Press_PickUpKey.SetActive(false);

                        Press_Exit.SetActive(false);
                    }
                }

                //If we press the interaction Button
                if (Input.GetButtonDown(interactButton))
                {
                    //Door
                    if (hit.collider.CompareTag("Door"))
                    {
                        hit.collider.GetComponent<Door>().ChangeDoorState();
                    }
                    else if (hit.collider.CompareTag("OpenDoor"))
                    {
                        hit.collider.GetComponent<OpenDoor>().ChangeDoorState();
                    }
                    else if (hit.collider.CompareTag("CloseDoor"))
                    {
                        hit.collider.GetComponent<CloseDoor>().ChangeDoorState();
                    }
                    else if (hit.collider.CompareTag("DoorUseOneTime"))
                    {
                        hit.collider.GetComponent<DoorOpenUseOneTime>().ChangeDoorState();
                    }
                    else if (hit.collider.CompareTag("DoorOpenUseOneTime"))
                    {
                        hit.collider.GetComponent<DoorOpenUseOneTime>().ChangeDoorState();
                    }
                    else if (hit.collider.CompareTag("DoorCloseUseOneTime"))
                    {
                        hit.collider.GetComponent<DoorCloseUseOneTime>().ChangeDoorState();
                    }
                    //LockDoor
                    else if (hit.collider.CompareTag("LockDoor"))
                    {
                        hit.collider.GetComponent<LockDoor>().PlayLockDoorSound();
                    }
                    else if (hit.collider.CompareTag("Doorislockneedkey"))
                    {
                        hit.collider.GetComponent<OpenDoor>().PlayLockDoorSound();
                    }
                    //Key
                    else if (hit.collider.CompareTag("Key"))
                    {
                        hit.collider.GetComponent<Key>().UnLockDoor();
                    }
                    //Note
                    else if (hit.collider.CompareTag("Note"))
                    {
                        hit.collider.GetComponent<Note>().ShowNoteImage();
                    }
                    else if (hit.collider.CompareTag("NoteGoToScence"))
                    {
                        hit.collider.GetComponent<NoteGoToScence>().ShowNoteImage();
                    }
                    else if (hit.collider.CompareTag("NoteGoToScenc2"))
                    {
                        hit.collider.GetComponent<NoteGoToScenc2>().ShowNoteImage();
                    }
                    else if (hit.collider.CompareTag("NoteChangScenes"))
                    {
                        hit.collider.GetComponent<NoteChangScenes>().ShowNoteImage();
                    }
                    else if (hit.collider.CompareTag("NoteChangeScence2"))
                    {
                        hit.collider.GetComponent<NoteChangeScence2>().ShowNoteImage();
                    }
                    else if (hit.collider.CompareTag("NoteToFinal"))
                    {
                        hit.collider.GetComponent<NoteToFinal>().ShowNoteImage();
                    }
                    //Final
                    else if (hit.collider.CompareTag("Final"))
                    {
                        hit.collider.GetComponent<Final>().END();
                    }
                }
            }
        }
        else
        {
            interactIcon.SetActive(false);
        }
    }
}


