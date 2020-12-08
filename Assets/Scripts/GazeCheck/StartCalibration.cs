using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCalibration : MonoBehaviour {
    public void OnClick () {
        GameObject calibObj =  GameObject.Find("Calibration");
        calibObj.GetComponent<Tobii.Research.Unity.Calibration>().Calibrate();
    }
}