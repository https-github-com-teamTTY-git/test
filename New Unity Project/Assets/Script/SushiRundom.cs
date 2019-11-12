﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiRundom : MonoBehaviour
{
    //乱数取得用変数
    public int newObjNum;          //現在の種別
    public int oldObjNum;          //前回の種別

    private void Start()
    {
        newObjNum = 0;
        oldObjNum = 0;
    }

    //乱数取得
    public int GetRandom(int range)
    {
        oldObjNum = newObjNum;
        int num = Random.Range(0, range);
        int repeate = 5;
        newObjNum = num;

        //前回と同じ種類であれば乱数を取り直す
        if(oldObjNum == newObjNum)
        {
            //最高5回繰り返し乱数を取り、違う種類が来た時点でループを抜ける
            for(int j = 0; j < repeate; j++)
            {
                num = Random.Range(0, range);
                newObjNum = num;
                if (oldObjNum != newObjNum)
                {
                    return num;
                }
            }
        }
        return num;
    }
}
