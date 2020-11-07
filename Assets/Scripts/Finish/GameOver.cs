using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    float firstMillis;
    void Start()
    {
        firstMillis = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - firstMillis > 3)
            Settings.Quit();
    }
}
