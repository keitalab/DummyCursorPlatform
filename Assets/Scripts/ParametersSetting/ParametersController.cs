using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public static bool isSet = false;
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
        isSet = true;
        Settings.cursorDiameter = float.Parse(diameterField.text);
        Settings.ScreenHeight = float.Parse(heightField.text);
        Settings.ScreenWidth = float.Parse(widthField.text);
        // Debug.Log(numberField1.text);
        // Debug.Log(numberField2.text);
        // Debug.Log(numberField3.text);
        // Debug.Log(numberField4.text);
        // Debug.Log(delayField.text);
        Settings.cursorSpeed = float.Parse(speedField.text);
        // Debug.Log(sessionField.text);
        SceneManager.LoadScene("StartScreen");
    }
}
