using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    [SerializeField]
    private int speed = 3;
    private Vector3 clickPos;
    private Vector3 pressPos;
    private float moveSmall = 100.0f;

    public bool leftFlag;                   // 左入力中にtrue(矢印に使う)
    public bool rightFlag;                  // 右入力中にtrue(矢印に使う)

    private TimerMng timerMng;

    void Start()
    {
        clickPos = new Vector3(0, 0, 0);
        leftFlag = false;
        rightFlag = false;

        timerMng = GameObject.Find("TimerText").GetComponent<TimerMng>();
    }

    void Update()
    {
        if (timerMng.TimerFlag == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))        // 左キーを押したとき
            {
                transform.Rotate(0, 0, speed);

                leftFlag = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))  // 右キーを押したとき
            {
                transform.Rotate(0, 0, -speed);

                rightFlag = true;
            }

            // 左キーを離したときの処理
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                leftFlag = false;
            }

            // 右キーを離したときの処理
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                rightFlag = false;
            }

            //タッチした瞬間
            if (Input.GetMouseButtonDown(0))
            {
                clickPos = Input.mousePosition;
            }

            //タッチしている間
            if (Input.GetMouseButton(0))
            {
                pressPos = Input.mousePosition;
                if((pressPos.x - clickPos.x) < -moveSmall)
                {
                    //左にまわす
                    transform.Rotate(0, 0, speed);
                    leftFlag = true;
                }
                if ((pressPos.x - clickPos.x) > moveSmall)
                {
                    //右にまわす
                    transform.Rotate(0, 0, -speed);
                    rightFlag = true;
                }
            }

            //離した瞬間
            if (Input.GetMouseButtonUp(0))
            {
                leftFlag = false;
                rightFlag = false;
            }
        }
    }
}
