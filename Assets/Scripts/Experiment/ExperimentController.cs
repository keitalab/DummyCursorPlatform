﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 本番用
public class ExperimentController : MonoBehaviour
{
    public CursorManager _cursorManager; // カーソル達の設定
    Table table;
    [SerializeField] private GameObject textPrefab; // カーソルのid表示用のtext
    List<GameObject> texts = new List<GameObject>();
    CursorManager cursorManager; // ダミーカーソルの初期設定をするため
    public Canvas _canvas;
    public GameObject background;
    bool isShowCursorId; // カーソルidを見せているか, 
    float firstMillis;
    bool isPressSpace;
    
    void Start()
    {
        // カーソル数取得
        int cursornum = Settings.getCursorNum(); 
        // カーソル準備キットみたいなもの
        cursorManager = Instantiate(_cursorManager, new Vector3(0, 0, 0), Quaternion.identity);
        // カーソルの事前準備
        cursorManager.init(cursornum);
        // カーソルの生成
        cursorManager.setCursors(
            -Settings.experimentCursorParams[Settings.experimentCount]["window"] / 2,
            Settings.experimentCursorParams[Settings.experimentCount]["window"] / 2,
            -Settings.experimentCursorParams[Settings.experimentCount]["window"] / 2,
            Settings.experimentCursorParams[Settings.experimentCount]["window"] / 2
        );
        
        isShowCursorId = false;
        isPressSpace = false;
        firstMillis = Time.time;

        // backgroundが4x4だから4で割る
        background.transform.localScale = new Vector2(
            Settings.experimentCursorParams[Settings.experimentCount]["window"] / 4,
            Settings.experimentCursorParams[Settings.experimentCount]["window"] / 4
        );

        // 画面サイズごとにカメラのサイズを調整
        Camera.main.orthographicSize = Screen.height / 2;
        // テーブルで管理
        table = new Table();
        table.addColumn("username");
        table.addColumn("cursornum");
        table.addColumn("primary_id");
        table.addColumn("cursor_id");
        table.addColumn("x");
        table.addColumn("y");
        table.addColumn("rotated_angle");
        table.addColumn("diameter");
        table.addColumn("window_size");
        table.addColumn("delay");
        table.addColumn("speed_rate");
        table.addColumn("time");

        if (Settings.isEyetrackingMode) {
            table.addColumn ("gaze_x");
            table.addColumn ("gaze_y");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPressSpace)
        {
            foreach (CursorObject cursor in cursorManager.cursors)
            {

            TableRow newRow = new TableRow();
            newRow.setString("username", Settings.userName);
            newRow.setInt("cursornum", cursorManager.cursors.Count);
            newRow.setInt("primary_id", cursor.primaryId);
            newRow.setInt("cursor_id", cursor.id);
            newRow.setFloat("x", cursor.x);
            newRow.setFloat("y", cursor.y);
            newRow.setFloat("rotated_angle", cursor.rad);
            newRow.setFloat("diameter", Settings.experimentCursorParams[Settings.experimentCount]["diameter"]);
            newRow.setFloat("window_size", Settings.experimentCursorParams[Settings.experimentCount]["window"]);
            newRow.setFloat("delay", Settings.experimentCursorParams[Settings.experimentCount]["delay"]);
            newRow.setFloat("speed_rate", Settings.experimentCursorParams[Settings.experimentCount]["speed"]);
            newRow.setFloat("time", Time.time - firstMillis);
            if (Settings.isEyetrackingMode)
            {
            newRow.setFloat("gaze_x", Settings.gazePos.x);
            newRow.setFloat("gaze_y", Settings.gazePos.y);
            }
            table.addRow(newRow);
            }
        }
        // spaceを押すとカーソルのidが表示
        if (!isShowCursorId && Input.GetKeyDown(KeyCode.Space))
        {
            cursorManager.stopCursors();
            Invoke("showCursorIds", Settings.experimentCursorParams[Settings.experimentCount]["delay"] / 1000 + 0.1f);
            isShowCursorId = true;
            isPressSpace = true;
        }

        // 右キーを押すか時間切れで次に進む
        if ((isShowCursorId && Input.GetKeyDown(KeyCode.RightArrow)) || (isTimeOut() && Settings.isLimitedTime))
        {
            // ファイル名を設定
            string saveFileName = Settings.userName
            + "_" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".csv";
            table.save("LogData/" + Settings.userName + "/" + saveFileName);
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
