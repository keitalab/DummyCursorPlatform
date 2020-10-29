﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCursorNumber : MonoBehaviour
{
    public InputField numberField;
    void Start()
    {
        numberField = numberField.GetComponent<InputField>();
    }

    
    public void Onclick()
    {
        Settings.cursornum.Add(int.Parse(numberField.text));
        numberField.text = "";
        for(int i=0; i < Settings.cursornum.Count; i++)
        Debug.Log(Settings.cursornum[i]);
    }
}
