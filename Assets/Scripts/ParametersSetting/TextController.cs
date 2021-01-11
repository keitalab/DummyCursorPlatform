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
    public Text countMax;
    public Text timeLimit;

    void Update()
    {
        paramsText(diameterText, Settings.cursorDiameters);
        paramsText(windowText, Settings.windowSizes);
        paramsText(numberText, Settings.cursornums);
        paramsText(delayText, Settings.cursorDelays);
        paramsText(speedText, Settings.cursorSpeeds);
        sessionText.text = Settings.experimentSessionCount.ToString();
        if(Settings.isLimitedTime)
        {
        timeLimit.text = Settings.timeLimitSeconds.ToString();
        timeLimit.fontSize = 30;
        }
        else
        {
        timeLimit.text = "∞";
        timeLimit.fontSize = 50;
        }
        
        ChangeCountMax();
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

    void ChangeCountMax()
    {
        countMax.text = "";
        countMax.text = (Settings.cursorDiameters.Count * Settings.windowSizes.Count * Settings.cursornums.Count *
                    Settings.cursorDelays.Count * Settings.cursorSpeeds.Count * Settings.experimentSessionCount).ToString();
    }
}
