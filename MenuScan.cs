using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScan : MonoBehaviour
{
    public GameObject UIRoot = null;    //null = 空值

    public GameObject menucanvas;
    public GameObject settimgcanvas;
    public GameObject MenuUIBackGround;

    public GameObject lodingScreen;
    public Slider slider;

    public Animator _animator;

    public CameraAnimator cameraanimator;

    void Start()
    {
        menucanvas.SetActive(true);
        settimgcanvas.SetActive(false);
        MenuUIBackGround.SetActive(true);

        _animator = GetComponent<Animator>();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        if (UIRoot != null)
        {
            int childCount = UIRoot.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = UIRoot.transform.GetChild(i).gameObject;

                if (child.name.Equals("NEW GAME"))    
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(NEWGAME);
                }

                if (child.name.Equals("LOAD"))    
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(LOAD);
                }

                if (child.name.Equals("SETTING"))   
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(SETTING);
                }

                if (child.name.Equals("Quit"))    
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Quit);
                }
            }
        }

    }

    public void NEWGAME()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        MenuUIBackGround.SetActive(false);

        StartCoroutine(LoadAsynchronously(1));
    }
    public void LOAD()
    {
        Debug.Log("Loading");
        
    }

    public void SETTING()
    {
        cameraanimator.GetComponent<CameraAnimator>().Playanimator();
        menucanvas.SetActive(false);
        Invoke("TestFunc", 3f);
    }
    public void Quit()
    {
        Application.Quit();
    }

    void TestFunc()
    {

        settimgcanvas.SetActive(true);
    }


    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        lodingScreen.SetActive(true);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);

            slider.value = progress;
            yield return null;

        }
    }
}
