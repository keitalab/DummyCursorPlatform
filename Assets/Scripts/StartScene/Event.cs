﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Event : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Settings.Quit();

    }
}
