using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Settings : MonoBehaviour {
    public static Settings Instance;

    public Camera _camera;

    // windowサイズ
    public static float ScreenWidth, ScreenHeight; // 必要か要吟味

    public static List<float> cursorDiameters = new List<float> () { 10 };
    public static List<float> windowSizes = new List<float> () { 1080 };
    public static List<float> cursornums = new List<float> () { 10 }; // これ全部で1セッション
    public static List<float> cursorSpeeds = new List<float> () { 1.0f };
    public static List<float> cursorDelays = new List<float> () { 0 };

    public static string userName;

    //c/d比
    public static float cursorSpeed = 1.0f;

    // 直径
    public static float cursorDiameter = 10f; // 消す

    public static int[] practiceCursornums = { 5, 10, 20, 50 }; // これ全部で1セッション

    // 遅延
    public static float cursorDelay = 0f;

    //カーソル数管理

    // 練習中 //
    // 練習のパラメータ管理
    public static List<Dictionary<string, float>> practiceCursorParams = new List<Dictionary<string, float>> ();
    // 練習のセッション数
    int practiceSessionCount = 1;
    public static int practiceCount = 0;
    public static int practiceCountMax;

    // 本番中 //
    // 本番のパラメータ管理
    public static List<Dictionary<string, float>> experimentCursorParams = new List<Dictionary<string, float>> ();
    // セッション数
    public static int experimentSessionCount = 5;
    // 現在の回数
    public static int experimentCount = 0;
    // 総回数
    public static int experimentCountMax;

    // 練習or本番
    public static bool isPractice = true;
    // 制限時間があるか否か
    public static bool isLimitedTime = true;
    //タイムリミット
    public static int timeLimitSeconds = 60;

    //アイトラッキングモードかどうか
    public static bool isEyetrackingMode = false;
    //アイトラッカーを取得しているのか
    public static bool isFoundEyetracker = false;
    public static Vector2[] calibrationPoints = {
        new Vector2 (0.2f, 0.2f),
        new Vector2 (0.8f, 0.2f),
        new Vector2 (0.2f, 0.8f),
        new Vector2 (0.8f, 0.8f),
        new Vector2 (0.5f, 0.5f)
    };
    public static Vector2 gazePos;
    public static String eyetrackerName = "Not Found";

    void Awake () {
        if (Instance == null) DontDestroyOnLoad (this);
        else Destroy (this);
    }

    void Start () {

        if (!ParametersController.isSet) {
            ScreenHeight = 2 * _camera.orthographicSize;
            ScreenWidth = ScreenHeight * Screen.width / Screen.height;
        }
        setPracticeCursorNum ();
        setExperimentCursorNum ();
    }

    // 練習の準備
    void setPracticeCursorNum () {
        practiceCursorParams.Clear ();
        practiceCountMax = 0;
        for (int i = 0; i < practiceSessionCount; i++) {
            foreach (int cursornum in cursornums) { // カーソル数
                foreach (float diameter in cursorDiameters) { // カーソル直径
                    foreach (float window in windowSizes) { // ウィンドウサイズ
                        foreach (float delay in cursorDelays) { // 遅延
                            foreach (float speed in cursorSpeeds) { // 速度
                                practiceCursorParams.Add (new Dictionary<string, float> () { { "cursornum", cursornum }, { "diameter", diameter }, { "window", window }, { "delay", delay }, { "speed", speed }
                                });
                                practiceCountMax++;
                            }
                        }
                    }
                }
            }
        }
    }

    // 本番用
    void setExperimentCursorNum () {
        experimentCursorParams.Clear ();
        experimentCountMax = 0;
        for (int i = 0; i < experimentSessionCount; i++) {
            foreach (int cursornum in cursornums) { // カーソル数
                foreach (float diameter in cursorDiameters) { // カーソル直径
                    foreach (float window in windowSizes) { // ウィンドウサイズ
                        foreach (float delay in cursorDelays) { // 遅延
                            foreach (float speed in cursorSpeeds) { // 速度
                                experimentCursorParams.Add (new Dictionary<string, float> () { { "cursornum", cursornum }, { "diameter", diameter }, { "window", window }, { "delay", delay }, { "speed", speed }
                                });
                                experimentCountMax++;
                            }
                        }
                    }
                }
            }
        }
        experimentCursorParams = experimentCursorParams.OrderBy (a => Guid.NewGuid ()).ToList ();
    }

    // カーソル数
    public static int getCursorNum () {
        if (isPractice) return (int) practiceCursorParams[practiceCount]["cursornum"];
        else return (int) experimentCursorParams[experimentCount]["cursornum"];
    }

    // セッション数を増やす
    public static void increaseSessionCount () {
        if (isPractice) practiceCount++;
        else experimentCount++;
    }

    // セッション数がmaxをoverしているかをチェック
    public static bool isSessionCountOver () {
        if (isPractice) return practiceCount >= practiceCountMax;
        else return experimentCount >= experimentCountMax;
    }

    public static void resetParams () {
        // 一度Clear
        Settings.cursornums.Clear ();
        Settings.cursorDelays.Clear ();
        Settings.cursorDiameters.Clear ();
        Settings.cursorSpeeds.Clear ();
        Settings.windowSizes.Clear ();
        // 初期値に戻す
        Settings.cursornums.AddRange (new List<float> () { 5, 10, 20, 50 });
        Settings.cursorDelays.AddRange (new List<float> () { 0, 500, 1000 });
        Settings.cursorDiameters.AddRange (new List<float> () { 10, 20, 30 });
        Settings.cursorSpeeds.AddRange (new List<float> () { 0.5f, 1.0f, 2.0f });
        Settings.windowSizes.AddRange (new List<float> () { 540, 810, 1080 });
        Settings.experimentSessionCount = 5;
    }

    public static void Quit () {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        UnityEngine.Application.Quit ();
#endif
    }

}