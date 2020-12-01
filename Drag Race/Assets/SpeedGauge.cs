using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedGauge : MonoBehaviour
{
    Acceleration carScript;
    void Start()
    {
        carScript = GameObject.Find("CarMover").GetComponent<Acceleration>();
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, (carScript.moveSpeed * -40) + 120);
    }
}
