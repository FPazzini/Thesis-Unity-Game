using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatorAndPoint : MonoBehaviour {

    public GameObject target;
    public float speed;
    private Vector3 initialPos;

    void Start() {
        initialPos = this.transform.position;
    }

    void Update () {
        transform.RotateAround(target.transform.position, new Vector3(0.0f, 0.0f, 2.0f), speed * Time.deltaTime);
     }

}
