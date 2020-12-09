using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecideEyetracking : MonoBehaviour {
    public void onClick () {
        if (Settings.isFoundEyetracker) {
            Settings.isEyetrackingMode = this.GetComponent<Toggle> ().isOn;
            Debug.Log(Settings.isEyetrackingMode);
        } else {
            this.GetComponent<Toggle>().isOn = false;
        }
    }
}