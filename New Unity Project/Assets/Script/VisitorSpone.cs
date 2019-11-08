﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorSpone : MonoBehaviour
{
    //席
    ChairMng chair;

    //来客モデルのプレハブリスト
    private List<GameObject> visitorObjList;
    private List<int> visitroCount;
    private int totalCnt;

    private int objNum;     //客の種類

    // スポーン用変数
    [SerializeField]
    private int spTimeSecond = default;     //スポーンする間隔(秒)
    private int flamNum;                    //フレーム数
    private int flamSecond = 60;            //1秒間のフレーム数

    // スポーン座標
    private Vector3[] sponePos =
                    {
                        new Vector3(-16,0,60),
                        new Vector3(  0,0,60),
                        new Vector3( 16,0,60)
                    };
    // Start is called before the first frame update
    private void Start()
    {
        //Visitorフォルダ内のprefabフォルダ内の全てのプレハブを取得
        Object[] visitorObj = Resources.LoadAll("prefab/visitor");
        visitorObjList = new List<GameObject>();
        visitroCount = new List<int>();
        foreach (GameObject obj in visitorObj)
        {
            visitroCount.Add(0);
            visitorObjList.Add(obj);
        }
        chair = GameObject.Find("ChairMng").GetComponent<ChairMng>();
        flamNum = 0;
        totalCnt = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        flamNum++;
        if(flamNum%(spTimeSecond*flamSecond)==0)
        {
            if (chair.CheckChair())
            {
                GameObject obj = Instantiate<GameObject>(visitorObjList[totalCnt % 5], sponePos[Random.Range(0, 2)], Quaternion.Euler(0, 180, 0));
                VisitorCon visitor = obj.GetComponent<VisitorCon>();
                visitor.SetDestination(chair.vacancy());
                visitroCount[totalCnt]++;
                totalCnt++;
            }
        }
    }
}
