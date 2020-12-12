using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class Table
{
    List<TableRow> rows;
    List<string> columns;
    List<string> columnTitles;
    string savePath;

    public Table()
    {
        rows = new List<TableRow>();
        columns = new List<string>();
    }

    // カラム追加
    public void addColumn(string column)
    {
        columns.Add(column);
    }


    // 列追加
    public void addRow(TableRow _row)
    {
        rows.Add(_row);
    }

    public void save(String _fileName)
    {
        // /(スラッシュ)付きでパスの連結 dataPath/fileName
        string filePath = Path.Combine(Application.dataPath, @_fileName);
        // Substring(部分文字列抽出) LastIndexOf(文字列が最後に見つかった場所)
        // StringComparison.CurrentCultureは形式的
        string dirPath = filePath.Substring(0, filePath.LastIndexOf("/", StringComparison.CurrentCulture));

        // ディレクトリが被っていなければ作成
        if (!Directory.Exists(dirPath))
        Directory.CreateDirectory(dirPath);

        // Tableファイルに書き込む
        try
        {
        // ファイル名をつけて作成
        using (StreamWriter sw = File.CreateText(filePath))
        {

            //最初にcolumns（ヘッダーの内容）を書き込む
            sw.WriteLine(format(columns));

            //取得した情報を書き込む
            foreach (TableRow row in rows)
                sw.WriteLine(format(row));
            sw.Close();
        }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    string format(List<string> _columns)
    {
        string str = "";
        int lastIndex = _columns.Count - 1;

        for (int i = 0; i < lastIndex; i++)
        str += _columns[i] + ",";

        str += _columns[lastIndex];

        return str;

    }
    string format(TableRow row)
    {
        string str = "";
        int lastIndex = columns.Count - 1;

        for (int i = 0; i < lastIndex; i++)
        str += row.getObject(columns[i]) + ",";

        str += row.getObject(columns[lastIndex]);

        return str;

    }
}