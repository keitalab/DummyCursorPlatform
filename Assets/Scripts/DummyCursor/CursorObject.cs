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
    float delay;

    float timer = 0f;
    float waitingTime = 0.1f;

    public Camera _camera;

    void Start()
    {
        if(Settings.isPractice)
        {
            // カーソルの速度調整
            // speed = Settings.cursorSpeed * _camera.orthographicSize / 5;
            speed = Settings.cursorSpeed * 160;
            delay = Settings.cursorDelay / 1000;
            this.transform.localScale = new Vector2(Settings.cursorDiameter / 10, Settings.cursorDiameter / 10);
        }
        else if(!Settings.isPractice && Settings.experimentCount < Settings.experimentCountMax)
        {
            speed = Settings.experimentCursorParams[Settings.experimentCount]["speed"] * 100;
            delay = Settings.experimentCursorParams[Settings.experimentCount]["delay"] / 1000;
            this.transform.localScale = new Vector2(
                Settings.experimentCursorParams[Settings.experimentCount]["diameter"] / 10,
                Settings.experimentCursorParams[Settings.experimentCount]["diameter"] / 10
            );
        }
    }

    void Update()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mouseMoveY = Input.GetAxis("Mouse Y");
        if (isMoved)
        {
            StartCoroutine(DelayCursor(delay, () =>
            {
                move(mouseMoveX, mouseMoveY);
            }));
        }
        if(Settings.isPractice)
        {
            torus(Settings.ScreenHeight);
        }
        else if(!Settings.isPractice && Settings.experimentCount < Settings.experimentCountMax)
        {
            torus(Settings.experimentCursorParams[Settings.experimentCount]["window"]);
        }
        
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

    public void torus(float windowSize)
    {
        // 画面外にでたら反対側から出てくるやつ
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        if (pos.x < -windowSize/2) pos.x = windowSize/2;
        if (pos.x > windowSize/2) pos.x = -windowSize/2;
        if (pos.y < -windowSize/2) pos.y = windowSize/2;
        if (pos.y > windowSize/2) pos.y = -windowSize/2;

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
