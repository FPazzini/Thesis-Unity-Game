using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    public PlayerProgress playerProgress;
    public GameObject saveScoreCanvas;
    public GameObject highestScoreMessage;

    public int numberOfHighScores;

    public void RestartGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveScore () {
        highestScoreMessage.SetActive(false);
        saveScoreCanvas.SetActive(true);
    }

    public void BackToMainMenu () {
        SceneManager.LoadScene("MenuScene");
    }

    public void AddNewScore () {
        if (PlayerPrefs.HasKey("highScores")) {
            
        }
    }

    public void SavePlayerProgress() {
        Dictionary<string, int> scores = new Dictionary<string, int>();
        if (PlayerPrefs.HasKey("highScores")) {
            string[] allScores = PlayerPrefsX.GetStringArray("highScores");
            string[] tokens = null;
            for (int i = 0; i < allScores.Length; i++) {
                tokens = allScores[i].Split(':');
                scores.Add(tokens[0], int.Parse(tokens[1]));
            }
            Debug.Log("Dictionary: " + scores);
        }
    }

    
}
