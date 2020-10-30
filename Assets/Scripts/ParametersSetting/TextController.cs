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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        paramsText(diameterText, Settings.cursorDiameters);
        paramsText(windowText, Settings.windowSizes);
        paramsText(numberText, Settings.cursornums);
        paramsText(delayText, Settings.cursorDelays);
        paramsText(speedText, Settings.cursorSpeeds);
        sessionText.text = Settings.experimentSessionCount.ToString();
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
