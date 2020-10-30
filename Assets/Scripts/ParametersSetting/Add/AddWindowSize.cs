using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddWindowSize : MonoBehaviour
{
    public InputField windowField;
    void Start()
    {
        windowField = windowField.GetComponent<InputField>();
    }

    
    public void Onclick()
    {
        Settings.windowSizes.Add(float.Parse(windowField.text));
        windowField.text = "";
    }
}
