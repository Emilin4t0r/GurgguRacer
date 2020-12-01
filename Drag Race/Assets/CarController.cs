using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    public GameObject[] lanes;
    public int currentLane;
    Vector3 newPos;
    bool movingToLeft;
    bool movingToRight;

    void Start() {
        currentLane = 1;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0) {
            currentLane--;
            newPos = lanes[currentLane].gameObject.transform.position;
            movingToLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2) {
            currentLane++;
            newPos = lanes[currentLane].gameObject.transform.position;
            movingToRight = true;
        }

        if (movingToLeft) {
            if (transform.position.x > newPos.x)
                transform.Translate(-5, 0, 0);
            else {
                transform.position = newPos;
                movingToLeft = false;
            }
        }
        if (movingToRight) {
            if (transform.position.x < newPos.x)
                transform.Translate(5, 0, 0);
            else {
                transform.position = newPos;
                movingToRight = false;
            }
        }
    }
}
