using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameOverScript : MonoBehaviour {

    public GameObject gameOverCanvas;
    public GameObject highestScoreMessage;
    public GameObject finalScoreObject;

    private int finalScore;

	public void ToggleGameOver (bool toShow) {
        gameOverCanvas.SetActive(toShow);
    }

    public void SetFinalScore (int finalScore) {
        finalScoreObject.GetComponent<UnityEngine.UI.Text>().text += finalScore.ToString();
        this.finalScore = finalScore;
        if (PlayerPrefs.HasKey("highScores")) {
            string[] scores = PlayerPrefsX.GetStringArray("highScores");
            if(IsHighestScore(scores, finalScore)) {
                highestScoreMessage.SetActive(true);
            }
        }
    }

    public int GetFinalScore () {
        return this.finalScore;
    }

    public bool IsHighestScore(string[] scores, int currentScore) {
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

        if (sortedScores.Count == 0) return true;
        return currentScore > sortedScores.Values.First();
    }
}
