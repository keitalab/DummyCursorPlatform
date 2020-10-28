using UnityEngine;

// カーソル個々の設定
public class CursorObject : MonoBehaviour
{
    public int primaryId, id;
    public float x, y; // 現在位置
    public float rad; // 相対角度
    bool isMoved = true; // 動かせるか否か
    float speed; // 速さの倍率
    float diameter; // カーソルの直径

    void Start()
    {
        speed = Settings.cursorSpeed * 100;
        this.transform.localScale = new Vector2(Settings.cursorDiameter, Settings.cursorDiameter);
    }

    void Update()
    {
        if (isMoved) move();
        torus();
    }

    public void move()
    {
        // 動画見る
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mouseMoveY = Input.GetAxis("Mouse Y");
        float mouseMoveRad = Mathf.Atan2(mouseMoveY, mouseMoveX);
        float moveDist = speed * dist(mouseMoveX, mouseMoveY) / 2;
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
}
