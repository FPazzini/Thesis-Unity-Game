using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {
    
    float timeCounter = 0;

    public float speed;
    public float width;
    public float height;

    Vector3 initialPos;

    // Use this for initialization
    void Start () {
        initialPos = this.transform.position;
    }

    // Update is called once per frame
    void Update () {
        timeCounter += Time.deltaTime * speed;
        float x = initialPos.x + Mathf.Cos(timeCounter) * width;
        float y = initialPos.y + Mathf.Sin(timeCounter) * height;
        float z = initialPos.z;
        transform.position = new Vector3(x, y, z);
    }
}
