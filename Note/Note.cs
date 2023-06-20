using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class Note : MonoBehaviour
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
    }

    public void ShowNoteImage()
    {
        noteImage.SetActive(true);
        interactIcon.SetActive(false);
        PauseUIMenu.GetComponent<PauseUI>().enabled = false;

        GetComponent<AudioSource>().PlayOneShot(pickupSound);

        HideNoteButton.SetActive(true);

        FirstPersonCharacter.GetComponent<Interact>().enabled = false;
        player.GetComponent<FirstPersonController>().enabled = false;   //Stop FirstPersonController

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideNoteImage()
    {
        PauseUIMenu.GetComponent<PauseUI>().enabled = true;

        noteImage.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(putAwaySound);

        HideNoteButton.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        FirstPersonCharacter.GetComponent<Interact>().enabled = true;
        player.GetComponent<FirstPersonController>().enabled = true;

        Destroy(gameObject);
    }

}
