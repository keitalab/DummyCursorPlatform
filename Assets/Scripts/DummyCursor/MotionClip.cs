using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Forgevision.InputCapture
{
    //Motion保存用のデータクラス
    public class MotionClip
    {
        //Position及びRotationのアニメーションカーブ
        public class PosRotCurve
        {
        public AnimationCurve pos_xCurve;
        public AnimationCurve pos_yCurve;
        public PosRotCurve()
        {
            pos_xCurve = new AnimationCurve();
            pos_yCurve = new AnimationCurve();
        }
        public void AddKeyPostionAndRotation(float time, Vector3 position)
        {
            Debug.Log(position.x);
            pos_xCurve.AddKey(time, position.x);
            pos_yCurve.AddKey(time, position.y);
        }
        }
        //頭、両手の3点の位置及び回転を保存する。(追加可能)
        public PosRotCurve cursorCurve = new PosRotCurve();
    }
}