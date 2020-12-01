using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevGauge : MonoBehaviour {
    public float revs;
    Acceleration carScript;
    public GameObject gearIndicator;

    public AudioSource carSound;

    void Start() {
        carScript = GameObject.Find("CarMover").GetComponent<Acceleration>();
        carSound.Play();
    }

    void Update() {

        revs = carScript.moveSpeed - carScript.minSpeed;

        if (revs > 2) {
            revs = 2;
        }
        /*
        if (carScript.gear == 1) {
            revs /= 1.333333333333333f;
            revs += 0.5f;
        } else if (carScript.gear == 2) {
            revs /= 2f;
            revs += 1f; //minimiarvo
        } else if (carScript.gear == 3) {
            revs /= 4f;
            revs += 1.5f; //minimiarvo
        }*/

        gearIndicator.GetComponent<Text>().text = carScript.gear.ToString();

        transform.eulerAngles = new Vector3(0, 0, (revs * -120) + 120);
        //when shifting down, it fucks up

        carSound.pitch = revs; //+ 1f) / 2f;
        if (carScript.gear == 1) {
            carSound.pitch /= 1.333333333333333f;
            carSound.pitch += 0.5f;
        } else if (carScript.gear == 2) {
            carSound.pitch /= 2.666666666666666f;
            carSound.pitch += 1.25f;
        } else if (carScript.gear == 3) {
            carSound.pitch /= 4f;
            carSound.pitch += 1.5f;
        }

    }
}
