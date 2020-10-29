using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSpeed : MonoBehaviour
{
    public InputField speedField;
    void Start()
    {
        speedField = speedField.GetComponent<InputField>();
    }

    
    public void Onclick()
    {
        Settings.cursorSpeeds.Add(int.Parse(speedField.text));
        speedField.text = "";
    }
}
