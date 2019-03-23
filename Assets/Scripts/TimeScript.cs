using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScript : MonoBehaviour {

    public double timer;
    private bool minReached;

    public GameObject levelManager;
	
	// Update is called once per frame
	void Update () {
        if (!minReached) {
            timer -= Time.deltaTime;
            this.GetComponent<UnityEngine.UI.Text>().text = ((int)timer).ToString();
            if (timer < 0) {
                minReached = !minReached;
                CallGameOver();
            }
        }
	}

    private void CallGameOver () {
        levelManager.GetComponent<LevelManagerScript>().GameOver();
        gameObject.SetActive(false);
    }

    public void DecreaseTimer (int amount) {
        if (!minReached) {
            if (timer > amount) {
                timer -= amount;
            } else {
                timer = 0;
            }
        }
    }
}
