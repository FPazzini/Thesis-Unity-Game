using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScoreController : MonoBehaviour {

    public GameObject gameOverController;
    public GameObject gameOverScript;
    public GameObject inputFieldText;
    public GameObject finalScore;
    public GameObject nicknameAlreadyExistingError;
    private int score;

    private void Start() {
        // Setting final score value as title
        score = gameOverScript.GetComponent<GameOverScript>().GetFinalScore();
        finalScore.GetComponent<UnityEngine.UI.Text>().text += score.ToString();
    }

    public void SaveScore () {
        
        // Getting the nickname entered by the user
        string nickname = inputFieldText.GetComponent<UnityEngine.UI.InputField>().text;

        if (!CheckDuplicatedNickname(nickname)) {
            this.nicknameAlreadyExistingError.SetActive(false);
            if (PlayerPrefs.HasKey("highScores")) {
                // Retrieving the string array with a specific key
                string[] arr = PlayerPrefsX.GetStringArray("highScores");

                // Building the new record
                string newRecord = nickname + ":" + score;

                // Using a list for easier data management
                List<string> list = new List<string>();
                for (int i = 0; i < arr.Length; i++) {
                    list.Add(arr[i].ToString());
                }
                // Inserting the new record into the list
                list.Add(newRecord);
                // Switching from list to array
                string[] newStringArray = list.ToArray();
                // Setting back the array value to the PlayerPrefs
                PlayerPrefsX.SetStringArray("highScores", newStringArray);
            } else {
                // If key doesn't exist, it means it's the first time here and therefore we must create a new array, put the record in it, and assigning it to the PlayerPrefsX
                string toSave = nickname + ":" + score;
                string[] nString = new string[] { toSave };
                PlayerPrefsX.SetStringArray("highScores", nString);
            }

            gameObject.SetActive(false);
            gameOverController.GetComponent<GameOverController>().BackToMainMenu();
            gameOverController.SetActive(false);
        } else {
            this.nicknameAlreadyExistingError.SetActive(true);
        }
    }

    private bool CheckDuplicatedNickname (string nickname) {
        if (PlayerPrefs.HasKey("highScores")) {
            string[] arr = PlayerPrefsX.GetStringArray("highScores");
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i].ToString().Split(':')[0].Equals(nickname)) {
                    return true;
                }
            }
        }
        return false;
    }
}
