using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class PauseUI : MonoBehaviour
{
    string PlayerName = "Player";

    public GameObject UIRoot = null;

    public Transform canvas;
    public Transform player;
    public Transform interact;
    public GameObject InteractionIcon;

    public GameObject lodingScreen;
    public Slider slider;

    int sceneIndex;

    const string savePlayer = "SavePlayer";

    [System.Serializable]class saveDate
    {
        public string name;
        public int level;
        public int coin;
        public Vector3 playerPosition;
    }

    void Start()
    {
        if (UIRoot != null)
        {
            int childCount = UIRoot.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = UIRoot.transform.GetChild(i).gameObject;

                if (child.name.Equals("Resume"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Resume);
                }
                if (child.name.Equals("Menu"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Menu);
                }
                if (child.name.Equals("Quit"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Quit);
                }
                if (child.name.Equals("Save"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Save);
                }
                if (child.name.Equals("Load"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Load);
                }
                if (child.name.Equals("DeleteSave"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(DeleteSave);
                }
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //按Esc暫停
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                InteractionIcon.SetActive(false);
                Time.timeScale = 0;
                player.GetComponent<FirstPersonController>().enabled = false;
                interact.GetComponent<Interact>().enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                InteractionIcon.SetActive(true);
                Time.timeScale = 1;
                player.GetComponent<FirstPersonController>().enabled = true;
                interact.GetComponent<Interact>().enabled = true;
            }
        }
    }

    public void Resume()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<FirstPersonController>().enabled = true;
        interact.GetComponent<Interact>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Menu()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<FirstPersonController>().enabled = true;
        interact.GetComponent<Interact>().enabled = true;

        sceneIndex = 0;

        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Save()
    {
        SaveByPlayerPrefs();
    }

    public void Load()
    {
        LoadByPlayerPrefs();
    }

    public void DeleteSave()
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey(savePlayer);
    }

    void SaveByPlayerPrefs()
    {
        //PlayerPrefs.SetString("PlayerName", PlayerName);
        //PlayerPrefs.Save();

        saveDate date = new saveDate();

        date.name = "name1";
        date.level = 1;
        date.coin = 10;
        date.playerPosition = transform.position;

        SaveAndLoad.SaveSystem.SaveByPlayerPrefs(savePlayer, date);
    }

    void LoadByPlayerPrefs()
    {
        //string stest = PlayerPrefs.GetString("PlayerName", "Null");

        //Debug.Log(stest);

        var json = SaveAndLoad.SaveSystem.LoadFormPlayerPrefs(savePlayer);

        if (json != "")
        {
            var saveData = JsonUtility.FromJson<saveDate>(json);

            Debug.Log("name:" + saveData.name
                + ",level:" + saveData.level
                + ",coin:" + saveData.coin
                + ",playerPosition:" + saveData.playerPosition);
        }
        else
        {
            Debug.Log("No Save");
        }
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
