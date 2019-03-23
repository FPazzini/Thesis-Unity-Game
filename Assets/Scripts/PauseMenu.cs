using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    public GameObject tabletop;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
	}

    public void Resume () {
        tabletop.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause () {
        tabletop.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void BackToSelectionMenu () {
        SceneManager.LoadScene("SharkSelection");
    }

    public void QuitGame () {
        Application.Quit();
    }
}
