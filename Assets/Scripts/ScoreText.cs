using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour {

    private float speed;
    private Vector3 direction;
    private float fadeTime;

    void Update () {
        float translation = speed * Time.deltaTime;

       // trnsform.Translate(direction * translation);
    }

    public void Initialize (float speed, Vector3 direction) {
        this.speed = speed;
        this.direction = direction;
    }
}
