using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Final : MonoBehaviour
{
    public GameObject player;
    public GameObject playerinteract;
    public GameObject interactIcon;
    public GameObject PauseUIMenu;

    public GameObject background;
    public GameObject finalthank;
    public GameObject Producer;
    public GameObject All;
    public GameObject Psychosis;

    public MoveUp moveup;

    private AudioSource audioSource;
    public AudioClip FinalSound;
    public GameObject BGM;

    public GameObject lodingScreen;
    public Slider slider;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        All.SetActive(false);

        moveup.enabled = false;
    }
    public void END()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        PauseUIMenu.GetComponent<PauseUI>().enabled = false;

        player.GetComponent<FirstPersonController>().enabled = false;
        playerinteract.GetComponent<Interact>().enabled = false;
        interactIcon.SetActive(false);
        BGM.SetActive(false);

        audioSource.PlayOneShot(FinalSound);

        background.SetActive(true);
        finalthank.SetActive(true);

        Invoke("TestFunc", 5f);
    }

    void TestFunc()
    {
        finalthank.SetActive(false);
        Producer.SetActive(true);

        Invoke("TestFunc2", 5f);
    }

    void TestFunc2()
    {
        Producer.SetActive(false);
        All.SetActive(true);
        moveup.enabled = true;

        Invoke("TestFunc3", 21f);
    }

    void TestFunc3()
    {
        All.SetActive(false);
        moveup.enabled = false;
        Psychosis.SetActive(true);


        Invoke("TestFunc4", 5f);
    }

    void TestFunc4()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        player.GetComponent<FirstPersonController>().enabled = true;
        playerinteract.GetComponent<Interact>().enabled = true;

        int sceneIndex = 0;
        StartCoroutine(LoadAsynchronously(sceneIndex));
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
