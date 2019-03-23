using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour {

    public GameObject[] playableSharks;
    public GameObject shark;
    public GameObject deckManager;
    public GameObject hand;
    public GameObject scoreManager;
    public GameObject gameOverManager;
    public GameObject informationPanel;
    public GameObject timer;
    public GameObject errorNumber;
    public Animator scoreAnimator;
    public Animator timerAnimator;
    public Animator errorDecreasingTimerAnimator;
    public GameObject scoreObj;

    public Sprite gwsSprite;
    public Sprite hammerheadSprite;
    public GameObject jawPicture;

    private static int SECONDS_TO_WAIT_FOR_INFO = 10;

    public int numOfCardsToHold;

    private void Awake() {
        if ( BackgroundMusicScript.Instance != null) {
            GameObject go = GameObject.Find("BackgroundMusic");
            if (go != null) {
                Destroy(go);
            }
        }
    }

    private void Start() {
        this.scoreAnimator = scoreObj.GetComponent<Animator>();
        this.timerAnimator = timer.GetComponent<Animator>();
        this.errorDecreasingTimerAnimator = errorNumber.GetComponent<Animator>();
    }

    void OnEnable() {
        string selectedShark = PlayerPrefs.GetString("sharkToPlayWith");
        Debug.Log("Shark selected: " + selectedShark);
        switch (selectedShark) {
            case "Great White Shark":
                shark = Instantiate(playableSharks[0]) as GameObject;
                jawPicture.GetComponent<Image>().sprite = gwsSprite;
                break;
            case "Hammerhead Shark":
                shark = Instantiate(playableSharks[1]) as GameObject;
                jawPicture.GetComponent<Image>().sprite = hammerheadSprite;
                break;
            default:
                break;
        }
        
        // Preparo il deck
        deckManager.GetComponent<DeckManager>().PrepareDeck();
        // Lo mischio
        deckManager.GetComponent<DeckManager>().ShuffleDeck();
        // Ed istanzio le prime N carte
        deckManager.GetComponent<DeckManager>().InstantiateDeck(hand.transform, numOfCardsToHold);
    }

    public void PlayChompingSound () {
        shark.GetComponent<AudioSource>().Play();
    }

    public GameObject GetShark () {
        return this.shark;
    }

    public void PickCard () {
        deckManager.GetComponent<DeckManager>().PickUpCard(hand.transform);
    }

    public void IncreaseScore () {
        StartCoroutine(ManageScoreAnimation());
        scoreManager.GetComponent<ScoreTextManager>().IncreaseScore();
    }

    public void DecreaseTimer (int amount) {
        StartCoroutine(LaunchTimerError());
        StartCoroutine(ManageTimerAnimation());
        timer.GetComponent<TimeScript>().DecreaseTimer(amount);
    }

    public void GameOver () {
        gameOverManager.GetComponent<GameOverScript>().SetFinalScore(scoreManager.GetComponent<ScoreTextManager>().GetScore());
        gameOverManager.GetComponent<GameOverScript>().ToggleGameOver(true);
    }

    public void ShowInformation (string itemName) {
        // Attivo il panel
        this.informationPanel.SetActive(true);
        // Ottengo il primo figlio, ovvero il GameObject con il componente TextMeshPro
        Transform informationText = GameObject.Find("InfoPanel").transform.GetChild(0);
        switch (itemName) {
            case "ORCA":
                informationText.gameObject.GetComponent<TextMeshProUGUI>().text = "Orche e squali bianchi sono predatori all'apice della catena alimentare. Gli squali bianchi mangerebbero i cuccioli orca, mentre le orche adulte si cibano di squali giovani. Tuttavia, le orche sono molto più intelligenti di questi ultimi: hanno infatti capito che gli squali hanno fegati pieni di olio, e che possono essere storditi capovolgendoli, di conseguenza un'orca può inseguire uno squalo bianco, morderlo, capovolgerlo, e mangiarsene il fegato.";
                StartCoroutine(HideInformationPanel());
                break;
            default:
                break;
        }
    }

    IEnumerator ManageTimerAnimation () {
        this.timerAnimator.Play("DecreaseTimer");
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(this.timerAnimator.GetCurrentAnimatorClipInfo(0).LongLength);
        this.timerAnimator.Play("New State");
    }

    IEnumerator LaunchTimerError () {
        this.errorNumber.SetActive(true);
        this.errorDecreasingTimerAnimator.Play("DecreasingEffectAnimation");
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(this.errorDecreasingTimerAnimator.GetCurrentAnimatorClipInfo(0).LongLength);
        this.errorNumber.SetActive(false);
        this.errorDecreasingTimerAnimator.Play("New State");
    }

    IEnumerator ManageScoreAnimation () {
        this.scoreAnimator.Play("IncreaseScore");
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(this.scoreAnimator.GetCurrentAnimatorClipInfo(0).LongLength);
        this.scoreAnimator.Play("New State");
    }

    IEnumerator HideInformationPanel () {
        yield return new WaitForSeconds(SECONDS_TO_WAIT_FOR_INFO);
        this.informationPanel.SetActive(false);
    }

    
}
