﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 練習用
public class PracticeController : MonoBehaviour
{
    public CursorManager _cursorManager; // カーソル達の設定
    [SerializeField] private GameObject textPrefab; // カーソルのid表示用のtext
    List<GameObject> texts = new List<GameObject>();
    CursorManager cursorManager;
    public Canvas _canvas;

    public GameObject background;
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
        cursorManager.setCursors(
            -Settings.practiceCursorParams[Settings.practiceCount]["window"] / 2,
            Settings.practiceCursorParams[Settings.practiceCount]["window"] / 2,
            -Settings.practiceCursorParams[Settings.practiceCount]["window"] / 2,
            Settings.practiceCursorParams[Settings.practiceCount]["window"] / 2
        );
        isShowCursorId = isShowAnswer = false;
        firstMillis = Time.time;
        background.transform.localScale = new Vector2(
            Settings.practiceCursorParams[Settings.practiceCount]["window"] / 4,
            Settings.practiceCursorParams[Settings.practiceCount]["window"] / 4
        );
        // 画面サイズごとにカメラのサイズを調整
        Camera.main.orthographicSize = Screen.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // spaceを押すとカーソルのidが表示
        if (!isShowCursorId && Input.GetKeyDown(KeyCode.Space))
        {
            cursorManager.stopCursors();
            isShowCursorId = true;
            Invoke("showCursorIds", Settings.practiceCursorParams[Settings.practiceCount]["delay"] / 1000 + 0.1f);
        }

        // 次にsを押すと答えがわかる
        if (isShowCursorId && !isShowAnswer && Input.GetKey("s"))
        {
            cursorManager.showRealCursor();
            isShowAnswer = true;
        }

        // 右キーを押すか時間切れで次に進む
        if (isShowAnswer && Input.GetKeyDown(KeyCode.RightArrow) || (isTimeOut() && Settings.isLimitedTime))
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
                Settings.isPractice = false;
            }
        }
    }


    // カーソルidをカーソル(丸)上に表示
    void showCursorIds()
    {
        foreach (CursorObject cursor in cursorManager.cursors)
        {
            // textオブジェクト生成
            GameObject text = Instantiate(textPrefab, new Vector3(cursor.x, cursor.y, 0), Quaternion.identity, _canvas.transform);
            // テキスト表示
            text.gameObject.SetActive(true);
            // テキスト(id)を配置
            text.GetComponent<RectTransform>().position = RectTransformUtility.WorldToScreenPoint(Camera.main, new Vector3(cursor.x, cursor.y, 0));
            // text.GetComponent<RectTransform>().position = new Vector3(cursor.x, cursor.y, 0);
            text.GetComponent<Text>().text = (cursor.id).ToString();
            texts.Add(text);
        }
    }

    // 制限時間
    bool isTimeOut()
    {
        return Time.time - firstMillis >= Settings.timeLimitSeconds;
    }
}
