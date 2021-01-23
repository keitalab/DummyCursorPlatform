using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Moments;

public class AnimationController : MonoBehaviour
{
    public GameObject cursor;
    public GameObject background;
    public static int index;
    public Recorder rec;
    void Start()
    {
        cursor.transform.localScale = new Vector2(SelectFile.LogDiameter, SelectFile.LogDiameter);
        background.transform.localScale = new Vector2(SelectFile.LogWindowSize / 4, SelectFile.LogWindowSize / 4);
        Camera.main.orthographicSize = Screen.height / 2;
        cursor = Instantiate(cursor, new Vector3(0f, 0f, 0f), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if(index < SelectFile.count)
        {
            cursor.transform.position = new Vector3(SelectFile.LogCursorX[index], SelectFile.LogCursorY[index], 0f);
            index++;
        }
        else 
        {
            // rec.Save();
        }
    }
}
