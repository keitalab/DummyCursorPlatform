using UnityEngine;
using UnityEngine.UI;

public class StatusTextControllerScript : MonoBehaviour
{
    public Text statusText;
    void Start()
    {
        // カウントダウンの下のテキスト
        if (Settings.isPractice)
        statusText.text =
        "練習:" + (Settings.practiceCount + 1)
        + "/" + Settings.practiceCountMax
        + "\n" + "カーソル数: " + Settings.practiceCursorNum[Settings.practiceCount];
        else
        statusText.text =
        "本番:" + (Settings.experimentCount + 1)
        + "/" + Settings.experimentCountMax
        + "\n" + "カーソル数: " + Settings.experimentCursorNum[Settings.experimentCount];
    }
}
