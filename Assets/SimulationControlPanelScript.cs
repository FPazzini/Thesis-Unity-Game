using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimulationControlPanelScript : MonoBehaviour {

    public GameObject startingGameText;
    private static string STARTING_GAME_TEXT = "La partita inizia fra... ";
    private static string WRONG_JAW_MESSAGE = "Mascella sbagliata!";
    private GameObject currentShark;
    public List<GameObject> sharks;
    public GameObject sharkName;
    public GameObject sharkInfo;
    private bool isTimerRunning;
    Coroutine timerCoroutine;

    private void Start() {
        this.currentShark = sharks[0];
        this.currentShark.SetActive(true);
        SharkDetails sd = MapObjectNameToActualName(currentShark.name);
        this.SetTexts(sd.GetSharkName(), sd.GetSharkInfo());
    }

    private SharkDetails MapObjectNameToActualName(string objectName) {
        switch (objectName) {
            case "Great White Shark":
                return new SharkDetails("Squalo bianco", "Sono i più grandi pesci predatori sul pianeta. Da adulti misurano in media 460 centimetri di lunghezza, anche se sono stati osservati individui lunghi oltre sei metri e pesanti più di due tonnellate. I loro dorsi color ardesia si confondono col fondo roccioso delle coste, ma il loro nome viene dall'addome, invariabilmente bianco.\nSono grandi nuotatori, longilinei, a forma di siluro, con code potenti che possono spingerli fino a 25 chilometri orari. Quando attaccano una preda dal basso possono librarsi completamente dall'acqua con un salto, come le balene.\nPredatori altamente specializzati, le loro fauci hanno fino a 300 denti fitti e triangolari disposti in più file; sono provvisti di un fiuto eccezionale per individuare le prede, e possiedono organi in grado di percepire il debole campo elettromagnetico generato dagli animali. Si nutrono principalmente di leoni marini, foche, piccoli odontoceti, tartarughe marine, persino carcasse.\nPresenti nelle acque costiere fredde di tutto il mondo, non esistono dati affidabili sul loro numero. Gli scienziati comunque concordano tutti sul fatto che il loro numero stia precipitando a causa, tra gli altri fattori, della pesca intensiva e della cattura accidentale nelle reti.\nAttualmente lo squalo bianco è considerato specie vulnerabile.");
            case "Hammerhead Shark":
                return new SharkDetails("Squalo martello", "Gli squali martello (Sphyrnidae) sono abili predatori che sfruttano la strana forma della loro testa per individuare meglio le prede. Gli occhi posti alle estremità del capo permettono infatti a questi squali una visuale migliore rispetto ai loro parenti. Inoltre, il fatto di avere tutti gli organi sensoriali altamente specializzati disposti sull'ampia superficie a martello li aiuta a scandagliare i mari in maniera più efficace in cerca di cibo.\nIl pesce \"martello maggiore\" è il più grande fra le nove specie identificate di questo squalo. Può raggiungere i 6 metri di lunghezza e pesare fino a 450 chili.\nLa gran parte delle specie di squalo martello sono di piccola taglia e considerate innocue per l'uomo. Il pesce martello maggiore, sia per stazza che per aggressività, è potenzialmente pericoloso per l'uomo, anche se sono stati registrati solo pochi attacchi.\nIl numero di squali martello non è noto, ma le popolazioni appaiono stabili ovunque; alcune specie sono considerate minacciate.");
            default:
                return new SharkDetails("Nome non trovato", "");
        }
    }

    private void SetTexts(string sName, string sInfo) {
        sharkName.GetComponent<Text>().text = sName;
        sharkInfo.GetComponent<Text>().text = sInfo;
    }

    public void StartGame() {
        StartCoroutine(StartingGameTimer());
    }

    private void SetStartGameText(string counter) {
        this.startingGameText.GetComponent<Text>().text = STARTING_GAME_TEXT + " " + counter;
    }

    public void ClickWhiteShark () {
        this.EvaluateStartingGame("Great White Shark");
    }

    public void ClickHammerHeadShark () {
        this.EvaluateStartingGame("Hammerhead Shark");
    }

    public void NextShark() {
        GameObject previous = null;
        if (sharks.IndexOf(currentShark) + 1 < sharks.Count) {
            previous = currentShark;
            currentShark = sharks[sharks.IndexOf(currentShark) + 1];
        } else {
            previous = currentShark;
            currentShark = sharks[0];
        }
        previous.SetActive(false);
        currentShark.SetActive(true);
        SharkDetails sd = MapObjectNameToActualName(currentShark.name);
        this.SetTexts(sd.GetSharkName(), sd.GetSharkInfo());
        // TODO: instantiate shark
    }

    public void PreviousShark() {
        GameObject previous = null;
        if (sharks.IndexOf(currentShark) > 0) {
            previous = currentShark;
            currentShark = sharks[sharks.IndexOf(currentShark) - 1];
        } else {
            previous = currentShark;
            currentShark = sharks[sharks.Count - 1];
        }
        previous.SetActive(false);
        currentShark.SetActive(true);
        SharkDetails sd = MapObjectNameToActualName(currentShark.name);
        this.SetTexts(sd.GetSharkName(), sd.GetSharkInfo());
        // TODO: instantiate shark
    }

    public void EvaluateStartingGame(string jawName) {
        if (!jawName.Equals(currentShark.name)) {
            this.isTimerRunning = false;
            this.startingGameText.SetActive(true);
            this.startingGameText.GetComponent<Text>().text = WRONG_JAW_MESSAGE;
            if (timerCoroutine != null) 
                StopCoroutine(timerCoroutine);
        } else {
            this.startingGameText.SetActive(true);
            if (timerCoroutine == null || !this.isTimerRunning) {
                this.isTimerRunning = true;
                timerCoroutine = StartCoroutine(StartingGameTimer());
            }
        }
    }

    IEnumerator StartingGameTimer() {
        int counter = 3;
        this.SetStartGameText(counter.ToString());
        while (counter > 0) {
            yield return new WaitForSeconds(1);
            counter--;
            this.SetStartGameText(counter.ToString());
        }
        this.isTimerRunning = false;
        Debug.Log("Shark name: " + this.currentShark.name);
        PlayerPrefs.SetString("sharkToPlayWith", this.currentShark.name);
        SceneManager.LoadScene("Game");
    }
}
