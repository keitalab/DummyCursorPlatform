using UnityEngine;
using System.Collections;
using System;

// カーソル個々の設定
public class CursorObject : MonoBehaviour
{
    public int primaryId, id;
    public float x, y; // 現在位置
    public float rad; // 相対角度
    bool isMoved = true; // 動かせるか否か
    float speed; // 速さの倍率
    float diameter; // カーソルの直径

    float timer = 0f;
    float waitingTime = 0.1f;

    void Start()
    {
        speed = Settings.cursorSpeed * 100;
        this.transform.localScale = new Vector2(Settings.cursorDiameter, Settings.cursorDiameter);
    }

    void Update()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mouseMoveY = Input.GetAxis("Mouse Y");
        if (isMoved)
        {
            StartCoroutine(DelayCursor(1f, () =>
            {
                move(mouseMoveX, mouseMoveY);
            }));
        }
        torus();
    }

    public void move(float ax, float ay)
    {
        float mouseMoveRad = Mathf.Atan2(ay, ax);
        float moveDist = speed * dist(ax, ay) / 2;
        float cursorMoveX = moveDist * Mathf.Cos(rad + mouseMoveRad);
        float cursorMoveY = moveDist * Mathf.Sin(rad + mouseMoveRad);
        this.gameObject.transform.Translate(cursorMoveX, cursorMoveY, 0);

        x = this.transform.position.x;
        y = this.transform.position.y;

    }

    public void torus()
    {
        // 画面外にでたら反対側から出てくるやつ
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        if (pos.x < -Settings.ScreenWidth/2) pos.x = Settings.ScreenWidth/2;
        if (pos.x > Settings.ScreenWidth/2) pos.x = -Settings.ScreenWidth/2;
        if (pos.y < -Settings.ScreenHeight/2) pos.y = Settings.ScreenHeight/2;
        if (pos.y > Settings.ScreenHeight/2) pos.y = -Settings.ScreenHeight/2;

        myTransform.position = pos;

        x = pos.x;
        y = pos.y;
    }

    // 実際のカーソルを赤くする
    public void showRealCursor()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }

    // 動きを止める
    public void stop()
    {
        isMoved = false;
    }

    // 距離計算
    float dist(float moveX, float moveY)
    {
        return Mathf.Sqrt(moveX * moveX + moveY * moveY);
    }

    public static IEnumerator DelayCursor(float _waitTime, Action _action)
    {
        yield return new WaitForSeconds(_waitTime);
        _action();
    }
}
