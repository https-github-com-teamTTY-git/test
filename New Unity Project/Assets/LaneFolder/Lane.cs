using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    [SerializeField]
    private float requiredTime = 30.0f;     // 長押しの基準値

    [SerializeField]
    private int spinSpeed = 45;                  // レーンの回転速度

    private float timeCnt;                  // 長押し時間の経過
    private float framcnt;                  // フレーム
    private bool oneActionFlag;             // 一度だけ回すとき

    public bool leftFlag;                   // 左入力中にtrue(矢印に使う)
    public bool rightFlag;                  // 右入力中にtrue(矢印に使う)

    // Start is called before the first frame update
    void Start()
    {
        leftFlag = false;
        rightFlag = false;
        oneActionFlag = true;
        timeCnt = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // 左キー
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftFlag = true;

            if(oneActionFlag)
            {
                oneAct(spinSpeed);
            }

            framcnt++;
            timeCnt++;

            longPush(spinSpeed);
        }

        // 右キー
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightFlag = true;

            if (oneActionFlag)
            {
                oneAct(-spinSpeed);
            }

            framcnt++;
            timeCnt++;

            longPush(-spinSpeed);
        }

        // 左キーを離したときの処理
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            leftFlag = false;
            KeyUpInit();
        }

        // 右キーを離したときの処理
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rightFlag = false;
            KeyUpInit();
        }

        // 1回押しの時
        void oneAct(int speed)
        {
           transform.Rotate(0, 0, speed);
           oneActionFlag = false;
        }

        // 長押し処理
        void longPush(int speed)
        {
            // 一定値を超えた場合を長押しと認める
            if (requiredTime < timeCnt)
            {
                // 毎フレーム更新すると凄い速さで回転してしまうので調整
                if (framcnt % (0.05 * 60) <= 0.1)
                {
                    transform.Rotate(0, 0, speed);
                }
            }
        }

        // キーを離したときの共通初期化
        void KeyUpInit()
        {
            framcnt = 0;
            oneActionFlag = true;
            timeCnt = 0.0f;
        }
    }
}
