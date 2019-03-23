using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManagerScript : MonoBehaviour
{
    public GameObject explanationPanel;
    public GameObject explanationBody;
    public GameObject explanationTitle;
    public GameObject closeExplanationButton;
    public GameObject introductionToTutorial;

    private void Start() {
        introductionToTutorial.SetActive(true);
        StartCoroutine(HideIntroductionToTutorial());
    }

    public void ManageExplanationPanelVisibility (bool isVisible) {
        this.explanationPanel.SetActive(isVisible);
    }

    public void CleanContents () {
        this.explanationTitle.GetComponent<Text>().text = "";
        this.explanationBody.GetComponent<Text>().text = "";
    }

    public void SetTitle (string title) {
        this.explanationTitle.GetComponent<Text>().text = title;
    }

    public void SetBody (string body) {
        this.explanationBody.GetComponent<Text>().text = body;
    }

    public void BackToMainMenu () {
        SceneManager.LoadScene("MenuScene");
    }

    IEnumerator HideIntroductionToTutorial () {
        yield return new WaitForSeconds(10);
        this.introductionToTutorial.SetActive(false);
    }
}
