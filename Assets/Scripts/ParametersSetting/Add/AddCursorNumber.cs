using System.Collections;
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
        Settings.cursornum.Add(float.Parse(numberField.text));
        numberField.text = "";
    }
}
