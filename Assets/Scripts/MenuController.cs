using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public InputField nameField;
    public PlayerData playerData;
    public Text bestScoreText;
    // Start is called before the first frame update
    private void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        nameField.onValueChange.AddListener(delegate { LoadPlayerData(); });
    }
    public void StartGame()
    {
        playerData.SetPlayerName(nameField.text);
        SceneManager.LoadScene(1);
    }

    private void LoadPlayerData()
    {
        if (!string.IsNullOrEmpty(nameField.text))
        {
            playerData.playerName = nameField.text;
            playerData.LoadPlayerData(); // Load data based on the entered name
            bestScoreText.text = "Personal Best: " + playerData.personalBestScore;
        }
        else
        {
            bestScoreText.text = "Personal Best: 0";
        }
        
    }


}
