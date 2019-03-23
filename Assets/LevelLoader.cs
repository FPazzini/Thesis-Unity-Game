using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public GameObject loadingPanel;
    public Slider slider;
    public Text progressText;
    public GameObject menuManager;

    public void LoadLevel (string sceneName) {
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    IEnumerator LoadAsynchronously (string sceneName) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        
        foreach (Button b in transform.GetComponentsInChildren<Button>()) {
            b.enabled = false;
        }

        loadingPanel.SetActive(true);

        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            float prog = progress * 100;
            progressText.text = prog.ToString("f0") + "%"; 
            yield return null;
        }
    }

}
