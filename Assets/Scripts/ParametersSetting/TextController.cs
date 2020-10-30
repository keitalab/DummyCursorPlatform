using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text diameterText;
    public Text windowText;
    public Text numberText;
    public Text delayText;
    public Text speedText;
    public Text sessionText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        paramsText(diameterText, Settings.cursorDiameters);
        paramsText(windowText, Settings.windowSizes);
        paramsText(numberText, Settings.cursornum);
        paramsText(delayText, Settings.cursorDelays);
        paramsText(speedText, Settings.cursorSpeeds);
        sessionText.text = Settings.experimentSessionCount.ToString();
    }

    void paramsText(Text text, List<float> num)
    {
        text.text = "";
        text.text = "{";
        for (int i = 0; i < num.Count; i++)
        {
        if (i < num.Count - 1)
            text.text += " " + num[i] + " ,";
        else
            text.text += " " + num[i];
        }
        text.text += " }";
    }
}
