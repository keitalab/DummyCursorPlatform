using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParametersController : MonoBehaviour
{
    public InputField diameterField;
    public InputField heightField;
    public InputField widthField;
    public InputField numberField1;
    public InputField numberField2;
    public InputField numberField3;
    public InputField numberField4;
    public InputField delayField;
    public InputField speedField;
    public InputField sessionField;
    void Start()
    {
        diameterField = diameterField.GetComponent<InputField>();
        heightField = heightField.GetComponent<InputField>();
        widthField = widthField.GetComponent<InputField>();
        numberField1 = numberField1.GetComponent<InputField>();
        numberField2 = numberField2.GetComponent<InputField>();
        numberField3 = numberField3.GetComponent<InputField>();
        numberField4 = numberField4.GetComponent<InputField>();
        delayField = delayField.GetComponent<InputField>();
        speedField = speedField.GetComponent<InputField>();
        sessionField = sessionField.GetComponent<InputField>();
    }

    public void InputParameters()
    {
        Debug.Log(diameterField.text);
        Debug.Log(heightField.text);
        Debug.Log(widthField.text);
        Debug.Log(numberField1.text);
        Debug.Log(numberField2.text);
        Debug.Log(numberField3.text);
        Debug.Log(numberField4.text);
        Debug.Log(delayField.text);
        Debug.Log(speedField.text);
        Debug.Log(sessionField.text);
    }
}
