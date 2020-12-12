using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class SelectFile : MonoBehaviour
{
  List<string[]> csvDatas;
  bool isFirst = true;
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
          csvDatas = new List<string[]>();
          // 前に追加されている？
          // csvの一番したがcsvDatasの0番目
          if(!isFirst)
          {
            if(int.Parse(values[2]) == 0)
            {
            csvDatas.Add(values);
            Debug.Log(csvDatas[0][2]);
            }
          }
          isFirst = false;
          // コンソールに出力する
        }

  }
}
