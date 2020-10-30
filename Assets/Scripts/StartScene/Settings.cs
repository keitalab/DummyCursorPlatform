using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public Camera _camera;

    // windowサイズ
    public static float ScreenWidth, ScreenHeight;// 必要か要吟味
    public static List<float> windowSizes = new List<float>(){ 540, 810, 1080 };

    public static string userName;

    //c/d比
    public static float cursorSpeed = 1.0f;
    public static List<float> cursorSpeeds = new List<float>(){ 0.5f, 1.0f, 2.0f};

    // 直径
    public static float cursorDiameter = 10f; // 消す
    public static List<float> cursorDiameters = new List<float>(){ 10, 20, 30};

    // 遅延
    public static float cursorDelay = 0f;
    public static List<float> cursorDelays = new List<float>{ 0, 500, 1000};

    //カーソル数管理
    // public static int[] cursornums = { 5, 10, 20, 50 }; // これ全部で1セッション
    public static List<float> cursornums = new List<float>(){ 5, 10, 20, 50 };


    // 練習中
    public static List<int> practiceCursorNum = new List<int>();
    //セッション数管理
    int practiceSessionCount = 1; // 練習のセッション数
    public static int practiceCount = 0;
    public static int practiceCountMax;

  // 本番中
    // public static List<int> experimentCursorNum = new List<int>();
    public static List<Dictionary<string, float>> experimentCursorParams = new List<Dictionary<string, float>>();
    public static Dictionary<string, float> experimentCursorParam = new Dictionary<string, float>();
    public static int experimentSessionCount = 5; //パターンごとのセッション数
    public static int experimentCount = 0;
    
    public static int experimentCountMax;


    // 練習かどうか
    public static bool isPractice = true;

    //タイムリミット
    public static int timeLimitSeconds = 60;

    void Start()
    {
        DontDestroyOnLoad(this);
        if(!ParametersController.isSet)
        {
            ScreenHeight = 2 * _camera.orthographicSize;
            ScreenWidth = ScreenHeight * Screen.width / Screen.height;
        }
        setPracticeCursorNum();
        setExperimentCursorNum();
    }

    // 練習の準備
    void setPracticeCursorNum()
    {
    practiceCursorNum.Clear();
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
    experimentCursorParams.Clear();
    experimentCountMax = 0;
    for (int i = 0; i < experimentSessionCount; i++)
    {
        foreach (int cursornum in cursornums){ // カーソル数
            foreach (float diameter in cursorDiameters){ // カーソル直径
                foreach (float window in windowSizes){ // ウィンドウサイズ
                    foreach (float delay in cursorDelays){ // 遅延
                        foreach (float speed in cursorSpeeds){ // 速度
                            experimentCursorParams.Add(new Dictionary<string, float>(){
                                {"cursornum", cursornum},
                                {"diameter", diameter},
                                {"window", window},
                                {"delay", delay},
                                {"speed", speed}
                            });
                            experimentCountMax++;
                        }
                    }
                }
            }
        }
    }
    Debug.Log(experimentCountMax);
    experimentCursorParams = experimentCursorParams.OrderBy(a => Guid.NewGuid()).ToList();
    }

    // カーソル数
    public static int getCursorNum()
    {
        if (isPractice) return practiceCursorNum[practiceCount];
        else return (int)experimentCursorParams[experimentCount]["cursornum"];
    }

    // セッション数を増やす
    public static void increaseSessionCount()
    {
        if (isPractice) practiceCount++;
        else experimentCount++;
    }

    // セッション数がmaxをoverしているかをチェック
    public static bool isSessionCountOver()
    {
        if (isPractice) return practiceCount >= practiceCountMax;
        else return experimentCount >= experimentCountMax;
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
