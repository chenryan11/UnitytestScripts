using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    string PlayerName = "Player";

    const string savePlayer = "SavePlayer";

    class saveDate
    {
        public string name;
        public int level;
        public int coin;
        public Vector3 playerPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        SaveByPlayerPrefs();
        LoadByPlayerPrefs();
    }

    void SaveByPlayerPrefs()
    {
        //PlayerPrefs.SetString(savePlayer, PlayerName);
        //PlayerPrefs.Save();

        saveDate date = new saveDate();

        date.name = "name1";
        date.level = 1;
        date.coin = 10;
        date.playerPosition = transform.position;

        SaveSystem.SaveByPlayerPrefs(savePlayer, date);
    }

    void LoadByPlayerPrefs()
    {
        //string stest = PlayerPrefs.GetString(savePlayer, PlayerName);

        var json = SaveSystem.LoadFormPlayerPrefs(savePlayer);

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

    public void DeleteSave()
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey(savePlayer);
    }

    public static class SaveSystem
    {
        public static void SaveByPlayerPrefs(string Key, object data)
        {
            var json = JsonUtility.ToJson(data);

            PlayerPrefs.SetString(Key, json);
            PlayerPrefs.Save();

            Debug.Log("Save Succes");
        }

        public static string LoadFormPlayerPrefs(string key)
        {
            return PlayerPrefs.GetString(key, null);
        }
    }
}
