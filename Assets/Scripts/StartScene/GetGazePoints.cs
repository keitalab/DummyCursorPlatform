using System.Collections;
using System.Collections.Generic;
using Tobii.Research.Unity;
using UnityEngine;
using UnityEngine.UI;
public class GetGazePoints : MonoBehaviour {
    private EyeTracker _eyeTracker;
    private void Start () {

        DontDestroyOnLoad (this);
        _eyeTracker = EyeTracker.Instance;
    }

    private void Update () {
        if (!_eyeTracker) {
            return;
        }
        // Camera.main.orthographicSize = Screen.height / 2;
        float height = 2 * Camera.main.orthographicSize;
        float width = height * Screen.width / Screen.height;
        Vector2 rightGazePos = _eyeTracker.LatestProcessedGazeData.Right.GazePointOnDisplayArea;
        Vector2 leftGazePos = _eyeTracker.LatestProcessedGazeData.Left.GazePointOnDisplayArea;
        Vector2 gazePos = (rightGazePos + leftGazePos) / 2;
        if (!float.IsNaN (gazePos.x) && !float.IsNaN (gazePos.y)) {
            Settings.gazePos.x = width * gazePos.x -width / 2;
            Settings.gazePos.y = -(height * gazePos.y - height / 2);
        }
    }
}