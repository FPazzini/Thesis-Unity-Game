using System.IO.Ports;
using UnityEngine;
using System.Collections;
using System;
using TMPro;
using UnityEngine.UI;

public class ReadSerial : MonoBehaviour {
    SerialPort serialPort;
    public GameObject selectedSharkText;
    private string sharkName;
    private string previousSharkName;
    private static string waitingString = "attendo...";

    public GameObject selectionManager;

	// Use this for initialization
	void Start () {
        try {
            serialPort = new SerialPort("COM3", 115200);
            if (!serialPort.IsOpen) {
                serialPort.Open();
            }
            serialPort.ReadTimeout = 1;
        } catch (Exception e) {
            Debug.Log(e.ToString());
        }
	}
	
	// Update is called once per frame
	void Update () {
        try {
            sharkName = serialPort.ReadLine();
            if(!sharkName.Equals(previousSharkName)) {
                previousSharkName = sharkName;
                SetFoundSharkName(previousSharkName);
            }
        } catch (Exception e) {
            Debug.Log(e.ToString());
        }
	}

    public void SetFoundSharkName(string sharkName) {
        string jawName = MapJawToShark(this.sharkName);
        //this.selectedSharkText.GetComponent<Text>().text = jawName;
        SetSharkText(jawName);
        if (!jawName.Equals("attendo...") && !jawName.Equals("")) {
            this.selectionManager.GetComponent<SelectionManagerScript>().EvaluateStartingGame(jawName);
        }
    }

    public string MapJawToShark (string jawFound) {
        switch(jawFound) {
            case "greatwhiteshark":
                return "Great White Shark";
            case "hammerheadshark":
                return "Hammerhead Shark";
            default:
                return "attendo...";
        }
    }

    private void SetSharkText (string sharkReadName) {
        switch (sharkReadName) {
            case "Great White Shark":
                SetText(SharksNames.GREAT_WHITE_SHARK);
                break;
            case "Hammerhead Shark":
                SetText(SharksNames.GREAT_HAMMERHEAD_SHARK);
                break;
            default:
                break;
        }        
    }

    private void SetText (string name) {
        this.selectedSharkText.GetComponent<Text>().text = name;
        //string[] tokens = selectedSharkText.GetComponent<TextMeshProUGUI>().text.Split(' ');
        //tokens[1] = name;
        //selectedSharkText.GetComponent<TextMeshProUGUI>().text = tokens[0] + " " + tokens[1];
    }

    IEnumerator openPort() {
        yield return new WaitForSeconds(3);
    }
}
