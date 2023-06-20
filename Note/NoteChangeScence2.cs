using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class NoteChangeScence2 : MonoBehaviour
{
    public GameObject PlayerHUDCanvus = null;

    public GameObject noteImage;
    public GameObject HideNoteButton;
    public GameObject interactIcon;
    public GameObject PauseUIMenu;

    public AudioClip pickupSound;
    public AudioClip putAwaySound;

    public GameObject player;
    public GameObject FirstPersonCharacter;

    public GameObject Scenes3;
    public GameObject OddScenes;
    public GameObject NewScenes;
    public GameObject Blood;

    public GameObject Press;

    public GameObject BGMTrugger2;

    void Start()
    {
        if (PlayerHUDCanvus != null)
        {
            int childCount = PlayerHUDCanvus.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = PlayerHUDCanvus.transform.GetChild(i).gameObject;

                if (child.name.Equals("ChangeScence"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(ChangeScence);
                }
            }
        }

        noteImage.SetActive(false);
        HideNoteButton.SetActive(false);
        

        Scenes3.SetActive(false);
        OddScenes.SetActive(true);
        NewScenes.SetActive(false);
        Blood.SetActive(true);

        Press.SetActive(true);
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

    public void ChangeScence()
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

        Scenes3.SetActive(true);
        OddScenes.SetActive(false);
        NewScenes.SetActive(true);
        Blood.SetActive(false);

        BGMTrugger2.SetActive(false);
    }
}
