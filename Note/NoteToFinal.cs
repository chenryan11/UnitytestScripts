using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class NoteToFinal : MonoBehaviour
{
    public GameObject PlayerHUDCanvus = null;

    public GameObject noteImage;
    public GameObject HideNoteButton;
    public GameObject interactIcon;
    public GameObject Press;
    public GameObject PauseUIMenu;

    public AudioClip pickupSound;
    public AudioClip putAwaySound;

    public GameObject player;
    public GameObject FirstPersonCharacter;

    public GameObject door;
    public GameObject NewScence;
    public GameObject Hall_And_Office;
    public GameObject Scenes2;

    public GameObject FinalBGM;

    void Start()
    {
        if (PlayerHUDCanvus != null)
        {
            int childCount = PlayerHUDCanvus.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = PlayerHUDCanvus.transform.GetChild(i).gameObject;

                if (child.name.Equals("HideNoteButton"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(HideNoteImage);
                }
            }
        }

        noteImage.SetActive(false);
        HideNoteButton.SetActive(false);
        Press.SetActive(true);
        NewScence.SetActive(false);
        Hall_And_Office.SetActive(false);
        FinalBGM.SetActive(false);
    }

    public void ShowNoteImage()
    {
        interactIcon.SetActive(false);
        Press.SetActive(false);
        noteImage.SetActive(true);
        PauseUIMenu.GetComponent<PauseUI>().enabled = false;

        GetComponent<AudioSource>().PlayOneShot(pickupSound);

        HideNoteButton.SetActive(true);

        FirstPersonCharacter.GetComponent<Interact>().enabled = false;
        player.GetComponent<FirstPersonController>().enabled = false;   //Stop FirstPersonController

        door.transform.Rotate(0, -90, 0);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideNoteImage()
    {
        noteImage.SetActive(false);
        PauseUIMenu.GetComponent<PauseUI>().enabled = true;
        GetComponent<AudioSource>().PlayOneShot(putAwaySound);
        GetComponent<AudioSource>().PlayDelayed(1000f);

        FinalBGM.SetActive(true);

        HideNoteButton.SetActive(false);

        NewScence.SetActive(true);
        Hall_And_Office.SetActive(true);
        Scenes2.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        FirstPersonCharacter.GetComponent<Interact>().enabled = true;
        player.GetComponent<FirstPersonController>().enabled = true;

        Destroy(gameObject);
    }
}
