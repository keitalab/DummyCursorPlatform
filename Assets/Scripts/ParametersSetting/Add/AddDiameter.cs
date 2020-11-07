using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddDiameter : MonoBehaviour
{
    public InputField diameterField;
    void Start()
    {
        diameterField = diameterField.GetComponent<InputField>();
    }

    
    public void Onclick()
    {
        Settings.cursorDiameters.Add(float.Parse(diameterField.text));
        diameterField.text = "";
    }
}
