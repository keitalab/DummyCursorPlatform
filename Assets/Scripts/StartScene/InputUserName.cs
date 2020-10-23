using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// スタート画面の名前入力
public class InputUserName : MonoBehaviour
{
    public InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        // フォーム生成
        inputField = inputField.GetComponent<InputField>();
    }

    // Update is called once per frame
    public void InputText()
    {
        // 改行を消して、usernameに値を入れる。
        Settings.userName = inputField.text.Replace("\r", "").Replace("\n", "");
    }
}
