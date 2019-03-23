using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class MainMenu : MonoBehaviour {

    public GameObject leaderboard;
    public GameObject levelLoader;

	public void PlayGame () {
        SceneManager.LoadScene("SharkSelection");
    }

    public void QuitGame () {
        Debug.Log("Qui");
        Application.Quit();
    }

    public void OpenLeaderboard () {
        if (PlayerPrefs.HasKey("highScores")) {
            string[] scores = PlayerPrefsX.GetStringArray("highScores");
            Dictionary<string, int> results = this.GetScoresSorted(scores);
            this.leaderboard.SetActive(true);
            this.leaderboard.GetComponent<LeaderboardController>().SetPlaces(results);
        
        }
    }

    public void OpenTutorial () {
        //SceneManager.LoadScene("Tutorial");
        levelLoader.GetComponent<LevelLoader>().LoadLevel("Tutorial");
    }

    public Dictionary<string, int> GetScoresSorted (string[] scores) {
        Dictionary<string, int> dict = new Dictionary<string, int>();

        string[] tokens = null;
        for (int i = 0; i < scores.Length; i++) {
            tokens = scores[i].Split(':');
            dict.Add(tokens[0], int.Parse(tokens[1]));
        }
        
        Dictionary<string, int> sortedScores = new Dictionary<string, int>();

        foreach (KeyValuePair<string, int> kv in dict.OrderByDescending(val => val.Value).Take(3)) {
            sortedScores.Add(kv.Key, kv.Value);
        }

        return sortedScores;
    }

}
