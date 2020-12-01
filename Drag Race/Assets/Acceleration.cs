using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour {

    public float moveSpeed;
    public float maxSpeed;
    public float minSpeed;

    public float accelSpeed;
    public float brakingSpeed;

    bool accelerating;
    bool braking;

    bool canShiftUp;

    public int gear;

    void Start() {
        gear = 1;
        maxSpeed = 2;      
    }

    void Update() {
        

        switch (gear) {
            case 1:
                if (moveSpeed > 1.8f) {
                    canShiftUp = true;
                }
                break;
            case 2:
                if (moveSpeed > 3.8f) {
                    canShiftUp = true;
                }
                break;
            case 3:                
                break;
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            accelerating = true;
        } else {
            accelerating = false;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            braking = true;
        } else {
            braking = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canShiftUp) {
            ChangeGear("up");
            canShiftUp = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            ChangeGear("down");
        }


    }

    private void FixedUpdate() {

        if (accelerating) {
            accelSpeed = maxSpeed - moveSpeed;
        } else if (!accelerating) {
            accelSpeed = minSpeed - moveSpeed; //hidastuminen kun ei kaasua
            if (gear > 1 && moveSpeed < minSpeed) {
                ChangeGear("down");
            }
        }

        if (!braking)
            moveSpeed += accelSpeed / 100;
        else if (braking)
            moveSpeed -= brakingSpeed / 100;

        //Just an overflow check
        if (moveSpeed < 0) {
            moveSpeed = 0;
        }

        transform.Translate(new Vector3(0, 0, moveSpeed));
    }

    void ChangeGear(string upOrDown) {

        if (upOrDown == "up") {
            if (gear != 3)
                gear++;
            maxSpeed = gear * 2;
            minSpeed = maxSpeed - 2;
        } else if (upOrDown == "down") {
            if (gear != 1) {
                gear--;
            }
            maxSpeed = gear * 2;
            minSpeed = maxSpeed - 2;
        }
    }
}
