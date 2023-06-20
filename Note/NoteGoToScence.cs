using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


public class NoteGoToScence : MonoBehaviour
{
    public GameObject UIRoot = null;

    public GameObject noteImage;
    public GameObject HideNoteButton;
    public GameObject interactIcon;
    public GameObject PauseUIMune;

    public AudioClip pickupSound;
    public AudioClip putAwaySound;

    public GameObject player;
    public GameObject FirstPersonCharacter;
    //Loding
    public GameObject lodingScreen;
    public Slider slider;

    public GameObject Press;


    void Start()
    {
        if (UIRoot != null)
        {
            int childCount = UIRoot.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = UIRoot.transform.GetChild(i).gameObject;

                if (child.name.Equals("NoteGoToScence"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(GoToScence);
                }
            }
        }

                noteImage.SetActive(false);
        HideNoteButton.SetActive(false);
        //interactIcon.SetActive(true);
        Press.SetActive(true);
    }

    public void ShowNoteImage()
    {
        noteImage.SetActive(true);
        interactIcon.SetActive(false);
        Press.SetActive(false);
        PauseUIMune.GetComponent<PauseUI>().enabled = false;

        GetComponent<AudioSource>().PlayOneShot(pickupSound);

        HideNoteButton.SetActive(true);

        FirstPersonCharacter.GetComponent<Interact>().enabled = false;
        player.GetComponent<FirstPersonController>().enabled = false;   

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GoToScence()
    {
        noteImage.SetActive(false);

        GetComponent<AudioSource>().PlayOneShot(putAwaySound);

        HideNoteButton.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player.GetComponent<FirstPersonController>().enabled = true;

        StartCoroutine(LoadAsynchronously(3));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        lodingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            yield return null;
        }
    }
}
