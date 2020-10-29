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
        Settings.windowSizes.Add(int.Parse(windowField.text));
        windowField.text = "";
        for(int i=0; i < Settings.windowSizes.Count; i++)
        Debug.Log(Settings.windowSizes[i]);
    }
}
