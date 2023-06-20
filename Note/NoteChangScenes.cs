using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class NoteChangScenes : MonoBehaviour
{
    public GameObject UIRoot = null;

    public GameObject noteImage;
    public GameObject HideNoteButton;
    public GameObject interactIcon;
    public GameObject PauseUIMenu;

    public AudioClip pickupSound;
    public AudioClip putAwaySound;

    public GameObject player;
    public GameObject FirstPersonCharacter;

    public GameObject OddScenes;
    public GameObject NewScenes;
    public GameObject ScareSoundTrigger;

    public GameObject Press;

    void Start()
    {
        if (UIRoot != null)
        {
            int childCount = UIRoot.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = UIRoot.transform.GetChild(i).gameObject;

                if (child.name.Equals("ChangeScence"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(HideNoteImage);
                }
            }
        }

        noteImage.SetActive(false);
        HideNoteButton.SetActive(false);

        NewScenes.SetActive(false);

        ScareSoundTrigger.SetActive(false);
    }

    public void ShowNoteImage()
    {
        noteImage.SetActive(true);
        PauseUIMenu.GetComponent<PauseUI>().enabled = false;

        Press.SetActive(false);
        interactIcon.SetActive(false);

        GetComponent<AudioSource>().PlayOneShot(pickupSound);

        HideNoteButton.SetActive(true);

        FirstPersonCharacter.GetComponent<Interact>().enabled = false;
        player.GetComponent<FirstPersonController>().enabled = false;   //Stop FirstPersonController

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideNoteImage()
    {
        noteImage.SetActive(false);
        PauseUIMenu.GetComponent<PauseUI>().enabled = true;

        GetComponent<AudioSource>().PlayOneShot(putAwaySound);

        HideNoteButton.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        FirstPersonCharacter.GetComponent<Interact>().enabled = true;
        player.GetComponent<FirstPersonController>().enabled = true;

        Destroy(gameObject);

        OddScenes.SetActive(false);
        NewScenes.SetActive(true);

        ScareSoundTrigger.SetActive(true);
    }

}
