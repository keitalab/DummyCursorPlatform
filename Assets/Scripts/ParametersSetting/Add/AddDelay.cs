using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddDelay : MonoBehaviour
{
    public InputField delayField;
    void Start()
    {
        delayField = delayField.GetComponent<InputField>();
    }

    
    public void Onclick()
    {
        Settings.cursorDelays.Add(float.Parse(delayField.text));
        delayField.text = "";
    }
}
