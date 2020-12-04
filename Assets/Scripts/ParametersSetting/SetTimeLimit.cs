using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTimeLimit : MonoBehaviour
{
    public InputField timeLimitField;
    void Start()
    {
        timeLimitField = timeLimitField.GetComponent<InputField>();
    }

    // Update is called once per frame
    public void Onclick()
    {
        Settings.timeLimitSeconds = int.Parse(timeLimitField.text);
        timeLimitField.text = "";
    }
}
