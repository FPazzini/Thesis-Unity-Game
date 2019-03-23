using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndSpin : MonoBehaviour {

    public Transform target;

    public float distance;

    public float xSpeed;
    public float ySpeed;

    public float yMinLimit;
    public float yMaxLimit;

    private bool isBeingClicked;

    private float x;
    private float y;

	// Use this for initialization
	void Start () {
        Vector3 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;

        if (GetComponent<Rigidbody>()) {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (isBeingClicked) {
            if (Input.touchCount > 0) {
                if (target && Input.GetMouseButton(0)) {
                    x += Input.touches[0].deltaPosition.x * ySpeed * 0.02f;
                    y += Input.touches[0].deltaPosition.y * ySpeed * 0.02f;

                    y = ClampAngle(y, yMinLimit, yMaxLimit);

                    Quaternion rotation = Quaternion.Euler(y, x, 0);

                    transform.rotation = rotation;
                }
            }
        }
	}

    public float ClampAngle (float angle, float min, float max) {
        if (angle < -360) {
            angle += 360;
        }
        if (angle > 360) {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }

    private void OnMouseUpAsButton() {
        this.isBeingClicked = false;
    }

    private void OnMouseDown() {
        this.isBeingClicked = true;
    }

    private void OnMouseEnter() {
        Debug.Log(gameObject.name + "game object");
    }
}
