﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorCon : MonoBehaviour
{

    private Chair chair;
    private Table table;

    private bool poszFlag;  // X側に動かなくなった時true
    private bool posxFlag;  // Z側に動かなくなった時true
    public bool updateFlag; // XとZ両方がtrueの時true
    private bool backFlag;  // 帰る時true

    private string Destination; //行き先

    private StartText startText;
    // Start is called before the first frame update
    void Start()
    {
        startText = GameObject.Find("StartText").GetComponent<StartText>();
        gameObject.SetActive(true);

        table = GameObject.Find("Table").GetComponent<Table>();

        backFlag = false;
        Debug.Log(backFlag);
    }

    // Update is called once per frame
    void Update()
    {
        if (!backFlag)
        {
            chair = GameObject.Find(Destination).GetComponent<Chair>();
        }

        if (startText.startFlag == true)
        {
            // 処理しなくなった時が目的地
            if (Enter())
            {
                MoveX();
                if (posxFlag)
                {
                    MoveZ();
                }
            }
            //Debug.Log(gameObject.transform.position);

            // 到着したらposFlagをtrueにする
            if (poszFlag == true && posxFlag == true)
            {
                Angle();
                //Debug.Log("Flags true");
                updateFlag = true;
            }
            MoveBack();
        }
    }
    bool Enter()
    {
        if(gameObject.transform.position.z <= 45)
        {
            return true;
        }
        gameObject.transform.Translate(0, 0, 0.1f);
        return false;
    }
    void MoveX()
    {
        if (!posxFlag)
        {
            if (gameObject.transform.position.x < chair.gameObject.transform.position.x)
            {

                gameObject.transform.Translate(-0.1f, 0, 0);
                //Debug.Log("-X:false");
                posxFlag = false;

            }
            if (gameObject.transform.position.x > chair.gameObject.transform.position.x)
            {
                gameObject.transform.Translate(0.1f, 0, 0);
                //Debug.Log("+X:false");
                posxFlag = false;
            }
        }
        // 0.01以下なら止まった判定
        float XDiff = Mathf.Abs(chair.gameObject.transform.position.x - gameObject.transform.position.x);
        if (XDiff <= 0.1f)
        {
            posxFlag = true;
           // Debug.Log("posxFlag:true");
        }

    }

    void MoveZ()
    {
        if (!poszFlag)
        {
            if (gameObject.transform.position.z < chair.gameObject.transform.position.z)
            {
                gameObject.transform.Translate(0, 0, -0.1f);
              // Debug.Log("-Z:false");
                poszFlag = false;
            }
            if (gameObject.transform.position.z > chair.gameObject.transform.position.z)
            {
                gameObject.transform.Translate(0, 0, 0.1f);
               // Debug.Log("+Z:false");
                poszFlag = false;
            }
        }
        float ZDiff = Mathf.Abs(chair.gameObject.transform.position.z - gameObject.transform.position.z);
        if (ZDiff <= 0.1f)
        {
            poszFlag = true;
            //Debug.Log("poszFlag:true");

        }
    }

    void Angle()
    {

        Vector2 visitorPos = new Vector2(transform.position.x, transform.position.z); // 自分の座標(Vec2)
        Vector2 tablePos = new Vector2(table.transform.position.x, table.transform.position.z);

        Vector2 anglePos = tablePos - visitorPos;
        float angle = Mathf.Atan2(anglePos.y, anglePos.x) * Mathf.Rad2Deg;
        angle = Mathf.Abs(angle);
        transform.rotation = Quaternion.Euler(0, angle + 90.0f, 0);
        
    }

    void MoveBack()
    {
        if (!backFlag)
        {
            return;
        }
        if(transform.position.z<=-4.0f)
        {
            // 客消滅
            Destroy(gameObject);
        }
        transform.rotation = Quaternion.Euler(0, 180.0f, 0);
        gameObject.transform.Translate(0, 0, 0.1f);
    }

    public void Back()
    {
        if (Destination != null)
        {
            backFlag = true;
            Destination = null;
            Debug.Log(backFlag);
        }
    }

    //座る席
    public void SetDestination(string name)
    {
        Destination = name;
    }
    public string GetDestination()
    {
        return Destination;
    }
}
