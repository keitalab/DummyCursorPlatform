using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Forgevision.InputCapture
{
    public class MotionPlayer : MonoBehaviour
    {
        //モーション再生する対象
        [SerializeField]
        Transform _targetcursor;
        MotionClip _motionClip;
        float _startTime = 0f;
        float _delayTimeSec = 0f;

        enum PlayState
        {
        NONE,
        STOP,
        PLAYING
        }
        PlayState playState = PlayState.NONE;
        void Update()
        {
        MotionUpdate();
        }
        //motionClipからデータを取り出して、対象のPosition及びRotationを変化させる。
        void MotionUpdate()
        {
        switch (playState)
        {
            case PlayState.PLAYING:
            break;
            default:
            return;
        }
        float playTime = Time.time - _startTime - _delayTimeSec;

        if (playTime < 0f)
        {
            return;
        }
        if (_targetcursor != null)
        {
            _targetcursor.position = new Vector2(
                _motionClip.cursorCurve.pos_xCurve.Evaluate(playTime)
                , _motionClip.cursorCurve.pos_yCurve.Evaluate(playTime)
                );
        }
        }
        //_delayTime_sec秒遅れて再生させる。
        public void MotionPlay(MotionClip motionClip, float delayTimeSec = 1f)
        {
        if (_targetcursor == null)
        {
            Debug.LogWarning("モーション再生対象が設定されていません。");
            return;
        }
        _startTime = Time.time;
        _motionClip = motionClip;
        _delayTimeSec = delayTimeSec;
        Debug.Log("モーション再生。遅延は" + string.Format("{0:#.#}", this._delayTimeSec) + "秒");
        playState = PlayState.PLAYING;
        }
        public void MotionStop()
        {
        if (playState != PlayState.PLAYING)
        {
            return;
        }
        Debug.Log("モーション停止。");
        playState = PlayState.STOP;
        }
    }
}