using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class NoteGoToScenc2 : MonoBehaviour
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
    //Loding
    public GameObject lodingScreen;
    public Slider slider;

    public GameObject Press;

    public GameObject BackGround;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;

    void Start()
    {
        if (PlayerHUDCanvus != null)
        {
            int childCount = PlayerHUDCanvus.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = PlayerHUDCanvus.transform.GetChild(i).gameObject;

                if (child.name.Equals("NoteGoToScence"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(GoToScenc2);
                }
            }
        }

        noteImage.SetActive(false);
        HideNoteButton.SetActive(false);
        //interactIcon.SetActive(true);
        Press.SetActive(true);

        BackGround.SetActive(false);
        Text1.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);       
    }

    public void ShowNoteImage()
    {
        noteImage.SetActive(true);
        interactIcon.SetActive(false);
        Press.SetActive(false);
        PauseUIMenu.GetComponent<PauseUI>().enabled = false;

        GetComponent<AudioSource>().PlayOneShot(pickupSound);

        HideNoteButton.SetActive(true);

        FirstPersonCharacter.GetComponent<Interact>().enabled = false;
        player.GetComponent<FirstPersonController>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GoToScenc2()
    {
        noteImage.SetActive(false);

        GetComponent<AudioSource>().PlayOneShot(putAwaySound);

        HideNoteButton.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player.GetComponent<FirstPersonController>().enabled = true;

        BackGround.SetActive(true);
        Text1.SetActive(true);

        Invoke("TestFunc", 5f);      
    }


    void TestFunc()
    {
        Text1.SetActive(false);
        Text2.SetActive(true);

        Invoke("TestFunc2", 5f);
    }

    void TestFunc2()
    {
        Text2.SetActive(false);
        Text3.SetActive(true);
        Invoke("TestFunc3", 5f);
    }

    void TestFunc3()
    {
        BackGround.SetActive(false);
        Text3.SetActive(false);
        StartCoroutine(LoadAsynchronously(2));
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
