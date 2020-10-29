using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterText : MonoBehaviour
{
    Text diameters;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        diameters.text = Settings.cursorDiameter.ToString();
    }
}
