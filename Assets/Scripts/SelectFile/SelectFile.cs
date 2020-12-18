using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class SelectFile : MonoBehaviour
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
    public void OpenFile()
    {
        var path = EditorUtility.OpenFilePanel("Open csv", "", "CSV");
        if(string.IsNullOrEmpty(path)) return;
        StreamReader reader = new StreamReader(path);
        // 末尾まで繰り返す
        while (!reader.EndOfStream)
        {
            // CSVファイルの一行を読み込む
            string line = reader.ReadLine();
            // 読み込んだ一行をカンマ毎に分けて配列に格納する
            string[] values = line.Split(',');
            // 配列からリストに格納する
            if(!isFirst)
            {
                if(int.Parse(values[2]) == 0)
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
