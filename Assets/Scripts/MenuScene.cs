using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class MenuScene : MonoBehaviour
{
    public static MenuScene Instance;

    public InputField nameInput;

    public string playerName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetName()
    {
        playerName = nameInput.text;
    }

    [System.Serializable]
    class SaveData
    {
        public Text bestScore;
    }


    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.bestScore.text = data.bestScore.text;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

             = data.TeamColor;
        }
    }

}
