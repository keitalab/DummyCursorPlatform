﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 本番用
public class ExperimentController : MonoBehaviour
{
    public CursorManager _cursorManager; // カーソル達の設定
    [SerializeField] private GameObject textPrefab; // カーソルのid表示用のtext
    List<GameObject> texts = new List<GameObject>();
    CursorManager cursorManager; // ダミーカーソルの初期設定をするため
    public Canvas _canvas;
    bool isShowCursorId; // カーソルidを見せているか, 
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
        isShowCursorId = false;
        firstMillis = Time.time;
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

        // 右キーを押すか時間切れで次に進む
        if ((isShowCursorId && Input.GetKeyDown(KeyCode.RightArrow)) || isTimeOut())
        {
            // セッション数を+1
            Settings.increaseSessionCount();
            // 次があれば次へ、なければ終わり
            if (!Settings.isSessionCountOver())
            {
                SceneManager.LoadScene("CountDown");
            }
            else
            {
                SceneManager.LoadScene("Finish");
            }
        }
    }


    // カーソルidをカーソル(丸)上に表示
    void showCursorIds()
    {
        foreach (CursorObject cursor in cursorManager.cursors)
        {
        // 第四引数は親
        GameObject text = Instantiate(textPrefab, new Vector3(cursor.x, cursor.y, 0), Quaternion.identity, _canvas.transform);
        text.gameObject.SetActive(true);
        // スクリーン座標に返還
        text.GetComponent<RectTransform>().position = RectTransformUtility.WorldToScreenPoint(Camera.main, new Vector3(cursor.x, cursor.y, 0));
        text.GetComponent<Text>().text = (cursor.id).ToString();
        texts.Add(text);
        }
    }

    bool isTimeOut()
    {
        return Time.time - firstMillis >= Settings.timeLimitSeconds;
    }
}