using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Event : MonoBehaviour
{
    public static Event Instance;
    void Awake()
    {
        if(Instance == null) DontDestroyOnLoad(this);
        else Destroy(this);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Settings.Quit();

    }
}
