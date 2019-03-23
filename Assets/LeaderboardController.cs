using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardController : MonoBehaviour {

    public GameObject firstPlace;
    public GameObject secondPlace;
    public GameObject thirdPlace;

    public void SetPlaces (Dictionary<string, int> results) {
        int counter = 0;
        foreach (KeyValuePair<string, int> kv in results) {
            if (counter == 0) {
                firstPlace.GetComponent<TextMeshProUGUI>().text = kv.Key + ": " + kv.Value;
            }
            if (counter == 1) {
                secondPlace.GetComponent<TextMeshProUGUI>().text = kv.Key + ": " + kv.Value;
            }
            if (counter == 2) {
                thirdPlace.GetComponent<TextMeshProUGUI>().text = kv.Key + ": " + kv.Value;
            }
            counter++;
        }
    }
    
}
