using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject lodingScreen;
    public Slider slider;
    public Text progressText;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void NEW_GAME(int sceneIndex)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(LoadAsynchronously(sceneIndex));  
    }
    public void LOADING()
    {
        Debug.Log("Loading");
    }
    public void SETTING()
    {
       SceneManager.LoadScene("SETTING");
    }
    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        lodingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }
}
