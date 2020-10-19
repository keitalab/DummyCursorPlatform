using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// カーソル達共通の設定
public class CursorManager : MonoBehaviour
{
    public CursorObject _cursor;
    public List<CursorObject> cursors;
    public List<int> cursorIds;
    int cursornum;
    float minAngle = 45;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // カーソルの準備
    public void init(int _cursornum)
    {
        cursornum = _cursornum;
        cursorIds = new List<int>();

        // idをセット
        for (int i = 0; i < _cursornum; i++)
            cursorIds.Add(i);

        cursorIds = cursorIds.OrderBy(a => Guid.NewGuid()).ToList();//shuffle

        cursors = new List<CursorObject>();

    }

    // ランダム位置にカーソルを生成
    public void setCursors(float x_min, float x_max, float y_min, float y_max)
    {
        for (int i = 0; i < cursornum; i++)
        {
            float x = UnityEngine.Random.Range(x_min, x_max);
            float y = UnityEngine.Random.Range(y_min, y_max);
            // カーソル(丸)生成
            CursorObject cursor = Instantiate(_cursor, new Vector3(x, y, 0), Quaternion.identity);
            // カーソルの相対角度を決定
            cursor.rad = cursorAngle(i, cursornum, minAngle);
            cursor.primaryId = i;
            cursor.id = cursorIds[i];
            // カーソルのListに追加
            cursors.Add(cursor);
        }
    }


    // カーソルを止める
    public void stopCursors()
    {
        foreach (CursorObject cursor in cursors)
            cursor.stop();
    }

    // cursors[0](本物)をわかるようにする
    public void showRealCursor()
    {
        if (cursors.Count <= 0) return;
        cursors[0].showRealCursor();
    }

    // ラジアン換算
    float radians(float degree)
    {
        return degree * Mathf.Deg2Rad;
    }

    // ダミーカーソルの(マウスとの相対)角度生成
    float cursorAngle(int _index, int _cursorNum, float _minAngle)
    {
        if (_index == 0) return 0;
        float degree = _minAngle + (_index - 1) * (360 - 2 * _minAngle) / (_cursorNum - 2);
        return radians(degree);
    }
}
