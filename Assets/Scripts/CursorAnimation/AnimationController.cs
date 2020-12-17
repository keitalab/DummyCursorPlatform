using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject cursor;
    public GameObject background;
    int index;
    void Start()
    {
        cursor.transform.localScale = new Vector2(SelectFile.LogDiameter * 10, SelectFile.LogDiameter * 10);
        background.transform.localScale = new Vector2(SelectFile.LogWindowSize / 4, SelectFile.LogWindowSize / 4);
        Camera.main.orthographicSize = Screen.height / 2;
        cursor = Instantiate(cursor, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(index < SelectFile.count)
        cursor.transform.position = new Vector3(SelectFile.LogCursorX[index], SelectFile.LogCursorY[index], 0f);
        index++;
    }
}
