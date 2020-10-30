﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSession : MonoBehaviour
{
    public InputField sessionField;
    void Start()
    {
        sessionField = sessionField.GetComponent<InputField>();
    }

    
    public void Onclick()
    {
        Settings.experimentSessionCount = int.Parse(sessionField.text);
    }
}