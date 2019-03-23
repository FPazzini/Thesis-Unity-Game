using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempStartGame : MonoBehaviour {

	public void StartGame () {
        SceneManager.LoadScene("Game");
    }
}
