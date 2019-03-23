using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextManager : MonoBehaviour {

    public static float scoreText;
    public Text score;

    public void IncreaseScore() {
        if (score == null) {
            Debug.Log("è vuoto!");
        } else {
            string[] currentScore = score.GetComponent<UnityEngine.UI.Text>().text.Split(' ');
            int castInt = Int32.Parse(currentScore[1].ToString()) + 1;
            score.GetComponent<UnityEngine.UI.Text>().text = currentScore[0] + " " + castInt.ToString();
        }
    }

    public int GetScore () {
        string[] tokens = score.text.ToString().Split(' ');
        return Int32.Parse(tokens[1]);
    }

}
