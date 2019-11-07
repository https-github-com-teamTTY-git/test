using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    //[SerializeField]
    //private float requiredTime = 30.0f;     // 長押しの基準値

    //[SerializeField]
    //private int spinSpeed = 45;             // レーンの回転速度

    [SerializeField]
    private int speed = 3;

   //private float timeCnt;                  // 長押し時間の経過
   //private float framCnt;                  // フレーム
   //private bool oneActionFlag;             // 一度だけ回すとき

    public bool leftFlag;                   // 左入力中にtrue(矢印に使う)
    public bool rightFlag;                  // 右入力中にtrue(矢印に使う)


    // Start is called before the first frame update
    void Start()
    {
        //timeCnt = 0.0f;
        //framCnt = 0.0f;
        //oneActionFlag = true;
        leftFlag = false;
        rightFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))        // 左キーを押したとき
        { 
            transform.Rotate(0, 0, speed);

            leftFlag = true;

            //if(oneActionFlag)
            //{
            //   oneAct(spinSpeed);
            //}
            //
            //framCnt++;
            //timeCnt++;
            //
            //longPush(spinSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))  // 右キーを押したとき
        {
            transform.Rotate(0, 0, -speed);

            rightFlag = true;

            //if (oneActionFlag)
            //{
            //   oneAct(-spinSpeed);
            //}
            //framCnt++;
            //timeCnt++;
            //longPush(-spinSpeed);
        }

        // 左キーを離したときの処理
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            leftFlag = false;
            //KeyUpInit();
        }

        // 右キーを離したときの処理
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rightFlag = false;
            //KeyUpInit();
        }

        // 1回押しの時
        //void oneAct(int speed)
        //{
        //   //transform.Rotate(0, 0, speed);
        //   oneActionFlag = false;
        //}

        // 長押し処理
        //void longPush(int speed)
        //{
        //    // 一定値を超えた場合を長押しと認める
        //    if (requiredTime < timeCnt)
        //    {
        //        // 毎フレーム更新すると凄い速さで回転してしまうので調整
        //        if (framCnt % (0.05 * 60) <= 0.1)
        //        {
        //            transform.Rotate(0, 0, speed);
        //        }
        //    }
        //}

        // キーを離したときの共通初期化
        //void KeyUpInit()
        //{
        //    framCnt = 0;
        //    oneActionFlag = true;
        //    timeCnt = 0.0f;
        //}
    }
}
