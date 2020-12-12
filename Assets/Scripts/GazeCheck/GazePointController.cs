using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazePointController : MonoBehaviour {
    void Update () {
        this.transform.localPosition = Settings.gazePos;
    }
}