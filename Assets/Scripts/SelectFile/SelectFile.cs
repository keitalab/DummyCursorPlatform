using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using SFB;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

[RequireComponent(typeof(Button))]
public class SelectFile : MonoBehaviour, IPointerDownHandler
{
    public static string userName;
    public static List<float> LogCursorX = new List<float>();
    public static List<float> LogCursorY = new List<float>();
    public static float LogDiameter;
    public static float LogWindowSize;
    public static List<float> LogGazeX = new List<float>();
    public static List<float> LogGazeY = new List<float>();
    bool isFirst = true;
    public static int count=0;
    public Text fileName;

#if UNITY_WEBGL && !UNITY_EDITOR
    //
    // WebGL
    //
    [DllImport("__Internal")]
    private static extern void UploadFile(string gameObjectName, string methodName, string filter, bool multiple);
    public void OnPointerDown(PointerEventData eventData) {
        fileName.text = "No file";
        UploadFile(gameObject.name, "OnFileUpload", ".csv", false);
    }

    // Called from browser
    public void OnFileUpload(string url) {
        StartCoroutine(OutputRoutine(url));
    }
    
#else
    public void OnPointerDown(PointerEventData eventData) { }
    public void OpenFile()
    {
        
        var paths = StandaloneFileBrowser.OpenFilePanel( "Open csv File", "", "csv", true );
        Debug.Log(paths[0]);
        if (paths.Length > 0)
        {
        StartCoroutine(OutputRoutine(paths[0]));
        // StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
        }
        // if(string.IsNullOrEmpty(path[0])) return;
        // StreamReader reader = new StreamReader(path[0]);
        // // 末尾まで繰り返す
        // fileName.text = path[0];
        // while (!reader.EndOfStream)
        // {
        //     // CSVファイルの一行を読み込む
        //     string line = reader.ReadLine();
        //     // 読み込んだ一行をカンマ毎に分けて配列に格納する
        //     string[] values = line.Split(',');
        //     // 配列からリストに格納する
        //     if(!isFirst)
        //     {
        //         if(int.Parse(values[2]) == 0)
        //         {
        //             userName = values[0];
        //             LogCursorX.Add(float.Parse(values[4]));
        //             LogCursorY.Add(float.Parse(values[5]));
        //             LogDiameter = float.Parse(values[7]);
        //             LogWindowSize = float.Parse(values[8]);
        //             count++;
        //         }
        //     }
        //     isFirst = false;
        //     // コンソールに出力する
        // }
    }
#endif
    private IEnumerator OutputRoutine(string url)
    {
        var loader = new WWW(url);
        yield return loader;
        Debug.Log(url);
        // if (string.IsNullOrEmpty(url));
        StreamReader reader = new StreamReader(url);
        // 末尾まで繰り返す
        fileName.text = url;
        while (!reader.EndOfStream)
        {
            // CSVファイルの一行を読み込む
            string line = reader.ReadLine();
            // 読み込んだ一行をカンマ毎に分けて配列に格納する
            string[] values = line.Split(',');
            // 配列からリストに格納する
            if (!isFirst)
            {
            if (int.Parse(values[2]) == 0)
            {
                userName = values[0];
                LogCursorX.Add(float.Parse(values[4]));
                LogCursorY.Add(float.Parse(values[5]));
                LogDiameter = float.Parse(values[7]);
                LogWindowSize = float.Parse(values[8]);
                count++;
            }
            }
            isFirst = false;
            // コンソールに出力する
        }
    }
}
