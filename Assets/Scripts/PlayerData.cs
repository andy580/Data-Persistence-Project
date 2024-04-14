using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public string playerName;
    public int personalBestScore = 0;
    public string allTimeBestPlayer = "No One";
    public int allTimeBestScore = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }
    // Start is called before the first frame 
    public void SetPlayerName(string name)
    {
        playerName = name;
    }
    public void SetPersonalBestScore(int score)
    {
        personalBestScore = score;
    }
    public void SetAllTimeBest(string name, int score)
    {
        allTimeBestPlayer = name;
        allTimeBestScore = score;
    }

    public void SavePlayerData()
    {
        PlayerDataSerializable saveData = new PlayerDataSerializable
        {
            playerName = this.playerName,
            personalBestScore = this.personalBestScore
        };
        string jsonData = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/playerData_" + playerName + ".json", jsonData);
    }

    public void LoadPlayerData()
    {
        string filename = "/playerData_" + playerName + ".json";
        string path = Application.persistentDataPath + filename;
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            PlayerDataSerializable loadData = JsonUtility.FromJson<PlayerDataSerializable>(jsonData);
            playerName = loadData.playerName;
            personalBestScore = loadData.personalBestScore;
        } else
        {
            personalBestScore = 0;

        }
    }

    public void SaveAllTimeBest()
    {
        AllTimeData allTimeData = new AllTimeData
        {
            allTimeBestPlayer = this.allTimeBestPlayer,
            allTimeBestScore = this.allTimeBestScore
        };
        string data = JsonUtility.ToJson(allTimeData);
        File.WriteAllText(Application.persistentDataPath + "/alltimebest.json", data);
    }

    public void LoadAllTimeBest()
    {
        string path = Application.persistentDataPath + "/alltimebest.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            AllTimeData loadedData = JsonUtility.FromJson<AllTimeData>(data);
            if (loadedData.allTimeBestScore > allTimeBestScore)
            {
                allTimeBestScore = loadedData.allTimeBestScore;
                allTimeBestPlayer = loadedData.allTimeBestPlayer;
            }
        }
    }

}

[System.Serializable]
public class PlayerDataSerializable
{
    public string playerName;
    public int personalBestScore;
}
[System.Serializable]
public class  AllTimeData
{
    public string allTimeBestPlayer;
    public int allTimeBestScore;
}
