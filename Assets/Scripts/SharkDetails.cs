using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkDetails {

    private string sharkName;
    private string sharkInfo;

    public SharkDetails (string sharkName, string sharkInfo) {
        this.sharkName = sharkName;
        this.sharkInfo = sharkInfo;
    }

    public string GetSharkName() {
        return this.sharkName;
    }

    public string GetSharkInfo() {
        return this.sharkInfo;
    }
	
}
