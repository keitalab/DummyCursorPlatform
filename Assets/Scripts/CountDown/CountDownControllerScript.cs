using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// カウントダウンの制御
public class CountDownControllerScript : MonoBehaviour
{
  public Text timerText;

  public float totalTime;
  int seconds;

  // Use this for initialization
  void Start()
  {
    // カーソルを固定→いくらでも動かせる
    Cursor.lockState = CursorLockMode.Locked;
    // カーソルが見えなくなる
    Cursor.visible = false;
  }

  // Update is called once per frame
  void Update()
  {
    totalTime -= Time.deltaTime;
    // 小数点以下切り上げ
    // CeilToIntは引数以上の最小整数を返す
    seconds = Mathf.CeilToInt(totalTime);
    // textに文字列にして代入
    timerText.text = seconds.ToString();

    // 0以下になるまではreturn
    if (seconds > 0) return;
    // 練習と本番どっちに進むか
    if (Settings.isPractice)
      SceneManager.LoadScene("Practice");
    else
      SceneManager.LoadScene("Experiment");
  }
}
