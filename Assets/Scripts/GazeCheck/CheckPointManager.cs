using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour {
    public GameObject _checkPoint;
    private List<GameObject> checkPoints;
    void Start () {
        checkPoints = new List<GameObject> ();
        float height = 2 * Camera.main.orthographicSize;
        float width = height * Screen.width / Screen.height;
        foreach (Vector2 point in Settings.calibrationPoints) {
            float x = width * point.x - width / 2;
            float y = -(height * point.y - height / 2);
            GameObject checkPoint = Instantiate (_checkPoint, new Vector3 (x, y, 0), Quaternion.identity);
            checkPoints.Add (checkPoint);
        }

    }

}