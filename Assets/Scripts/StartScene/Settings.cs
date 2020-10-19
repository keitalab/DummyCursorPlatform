﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public Camera _camera;
    public static float ScreenWidth, ScreenHeight;

    //カーソル数管理
    int[] cursornums = { 5, 10, 20, 50 }; // これ全部で1セッション


    // 練習中
    public static List<int> practiceCursorNum = new List<int>();
    //セッション数管理
    int practiceSessionCount = 1; // 練習のセッション数
    public static int practiceCount = 0;
    public static int practiceCountMax;

  // 本番中
    public static List<int> experimentCursorNum = new List<int>();
    int experimentSessionCount = 5; //パターンごとのセッション数
    public static int experimentCount = 0;
    public static int experimentCountMax;


    // 練習かどうか
    public static bool isPractice = true;
    void Start()
    {
        DontDestroyOnLoad(this);

        ScreenHeight = 2 * _camera.orthographicSize;
        ScreenWidth = ScreenHeight * Screen.width / Screen.height;
        setPractiseCursorNum();
        setExperimentCursorNum();
    }

    // 練習の準備
    void setPractiseCursorNum()
    {
    for (int i = 0; i < practiceSessionCount; i++)
    {
        foreach (int cursornum in cursornums)
        practiceCursorNum.Add(cursornum);
    }
    practiceCountMax = practiceCursorNum.Count;
    }

    // 本番用
    void setExperimentCursorNum()
    {
    for (int i = 0; i < experimentSessionCount; i++)
        foreach (int cursornum in cursornums)
        experimentCursorNum.Add(cursornum);
    experimentCursorNum = experimentCursorNum.OrderBy(a => Guid.NewGuid()).ToList(); // シャッフル
    experimentCountMax = experimentCursorNum.Count;
    }

    public static void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
        #endif
    }

}
