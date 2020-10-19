﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeController : MonoBehaviour
{
    public CursorManager _cursorManager; // カーソル達の設定
    [SerializeField] private GameObject textPrefab; // カーソルのid表示用のtext
    List<GameObject> texts = new List<GameObject>();
    CursorManager cursorManager;
    public Canvas _canvas;
    bool isShowCursorId, isShowAnswer; // カーソルidを見せているか, 
    float firstMillis;
    void Start()
    {
        int cursornum = Settings.getCursorNum(); // カーソル数取得
        // カーソル準備キットみたいなもの
        cursorManager = Instantiate(_cursorManager, new Vector3(0, 0, 0), Quaternion.identity);
        // カーソルの事前準備
        cursorManager.init(cursornum);
        // カーソルの生成
        cursorManager.setCursors(-Settings.ScreenHeight / 2, Settings.ScreenHeight / 2, -Settings.ScreenHeight / 2, Settings.ScreenHeight / 2);
        firstMillis = Time.time;
        isShowCursorId = isShowAnswer = false;
    }

    // Update is called once per frame
    void Update()
    {
        // spaceを押すとカーソルのidが表示
        if (!isShowCursorId && Input.GetKeyDown(KeyCode.Space))
        {
            cursorManager.stopCursors();
            showCursorIds();
            isShowCursorId = true;
        }
        // 次にsを押すと答えがわかる
        if(isShowCursorId && !isShowAnswer && Input.GetKey("s"))
        {
            cursorManager.showRealCursor();
            isShowAnswer = true;
        }

        // 右キーを押すか時間切れで次に進む
        if (isShowAnswer && Input.GetKeyDown(KeyCode.RightArrow) || isTimeOut())
        {
            // セッション数を+1
            Settings.increaseSessionCount();
            // セッション数分終わったかどうか
            if (!Settings.isSessionCountOver())
            {
                SceneManager.LoadScene("CountDown");
            }
            else
            {
                SceneManager.LoadScene("BreakTime");
                Settings.isPractise = false;
            }
        }
    }
}