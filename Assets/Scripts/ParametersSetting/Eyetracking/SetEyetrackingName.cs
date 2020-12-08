using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetEyetrackingName : MonoBehaviour {
    public Text text;

    void Start () {
        text = this.GetComponent<Text> ();
    }

    void Update () {
        text.text = Settings.eyetrackerName;
        // Debug.Log(Settings.eyetrackerName);
        if (Settings.isFoundEyetracker) text.color = new Color (0.0f, 0.8f, 0.0f);
        else text.color = new Color (0.8f, 0.0f, 0.0f);
    }
}