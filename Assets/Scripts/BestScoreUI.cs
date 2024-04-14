using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreUI : MonoBehaviour
{
    public MainManager mainManager;
    public PlayerData playerData;

    // Start is called before the first frame update
    void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
        playerData.LoadAllTimeBest();
        playerData.LoadPlayerData();
        mainManager = FindObjectOfType<MainManager>();
    }

    public void UpdateBestScore()
    {
        if (mainManager.m_Points > playerData.personalBestScore)
        {
            playerData.personalBestScore = mainManager.m_Points;
            FindObjectOfType<PlayerData>().SavePlayerData();
            Debug.Log("Saved personal best score: ");
        }
        if (playerData.personalBestScore > playerData.allTimeBestScore)
        {
            playerData.allTimeBestScore = playerData.personalBestScore;
            playerData.allTimeBestPlayer = playerData.playerName;
            FindObjectOfType<PlayerData>().SaveAllTimeBest();
            Debug.Log("Saved all time best score: ");
        }
    }

    public void DisplayBestScores()
    {
        GetComponent<Text>().text = playerData.playerName + " Best: " + playerData.personalBestScore + "--" + playerData.allTimeBestPlayer + " : " + playerData.allTimeBestScore;
    }
}
