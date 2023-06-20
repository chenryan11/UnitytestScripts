using UnityEngine;

public class Door : MonoBehaviour
{
    public string interactButton;

    public bool open = false;   //Is for saving the door state
    public bool Close = true;
    private bool hasOpenedCompletly = false;
    public bool front = false;
    public bool back = false;
    public bool isLock = false;

    public float doorOpenAngle;
    public float doorClosedAngle;
    public float smooth = 3f;       //This the speed of the rotation

    private AudioSource audioSource;

    public AudioClip OpeningDoorSound;
    public AudioClip ClosingDoorSound;
    public AudioClip LockDoorSound;

    public GameObject DoorFront;
    public GameObject DoorBack;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeDoorState()
    {
        if (isLock != true)
        {
            open = !open;   //open = true

            if (Close != true)
            {
                if (open == true)
                {
                    audioSource.PlayOneShot(OpeningDoorSound);
                }
            }
            else //Close = true
            {
                audioSource.PlayOneShot(ClosingDoorSound);
            }
        }
        else //isLock = true
        {
            PlayLockDoorSound();
        }
    }

    void PlayLockDoorSound()
    {
        audioSource.PlayOneShot(LockDoorSound);
    }

    void Update()
    {
        if (open)
        {
            //front open the door
            if (front && hasOpenedCompletly == false) //front = true
            {
                Quaternion targetRotationOpen = Quaternion.Euler(0, -doorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);

                DoorBack.SetActive(false);

                if (transform.localRotation == targetRotationOpen)
                {
                    DoorBack.SetActive(true);
                    hasOpenedCompletly = true;
                    Close = true;
                }
            }
            //back open the door
            if (back && hasOpenedCompletly == false) //Back =true
            {
                Quaternion targetRotationOpen = Quaternion.Euler(0, doorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);

                DoorFront.SetActive(false);

                if (transform.localRotation == targetRotationOpen)
                {
                    DoorFront.SetActive(true);
                    hasOpenedCompletly = true;
                    Close = true;

                }
            }
        }
        else if (Close == true)
        {
            Quaternion targetRotationClose = Quaternion.Euler(0, doorClosedAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationClose, smooth * Time.deltaTime);

            if (transform.localRotation == targetRotationClose)
            {
                hasOpenedCompletly = false;
                Close = false;
            }

        }
    }
}
