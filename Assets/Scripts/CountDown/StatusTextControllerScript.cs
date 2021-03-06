﻿using UnityEngine;
using UnityEngine.UI;

public class StatusTextControllerScript : MonoBehaviour
{
    public Text statusText;
    public Text diameter;
    public Text window_size;
    public Text delay;
    public Text speed_rate;
    void Start()
    {
        // カウントダウンの下のテキスト
        if (Settings.isPractice)
        {
            statusText.text =
            "練習:" + (Settings.practiceCount + 1)
            + "/" + Settings.practiceCountMax
            + "\n" + "カーソル数: " + (int)Settings.practiceCursorParams[Settings.practiceCount]["cursornum"];
            diameter.text = Settings.practiceCursorParams[Settings.practiceCount]["diameter"].ToString() + "px";
            window_size.text = Settings.practiceCursorParams[Settings.practiceCount]["window"].ToString() + "px";
            delay.text = Settings.practiceCursorParams[Settings.practiceCount]["delay"].ToString() + "ms";
            speed_rate.text = Settings.practiceCursorParams[Settings.practiceCount]["speed"].ToString() + "倍";
        }
        else
        {
            statusText.text =
            "本番:" + (Settings.experimentCount + 1)
            + "/" + Settings.experimentCountMax
            + "\n" + "カーソル数: " + (int)Settings.experimentCursorParams[Settings.experimentCount]["cursornum"];
            diameter.text = Settings.experimentCursorParams[Settings.experimentCount]["diameter"].ToString() + "px";
            window_size.text = Settings.experimentCursorParams[Settings.experimentCount]["window"].ToString() + "px";
            delay.text = Settings.experimentCursorParams[Settings.experimentCount]["delay"].ToString() + "ms";
            speed_rate.text = Settings.experimentCursorParams[Settings.experimentCount]["speed"].ToString() + "倍";
        }
    }
}
