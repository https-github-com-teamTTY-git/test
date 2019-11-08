using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorCon : MonoBehaviour
{

    private Chair chair;
    private Table table;

    private bool poszFlag;  // X側に動かなくなった時true
    private bool posxFlag;  // Z側に動かなくなった時true
    public bool updateFlag; // XとZ両方がtrueの時true

    private StartText startText;
    // Start is called before the first frame update
    void Start()
    {
        startText = GameObject.Find("StartText").GetComponent<StartText>();
        gameObject.SetActive(true);

        GameObject obj = GameObject.Find("Chair_2");
        chair = obj.GetComponent<Chair>();

        table = GameObject.Find("Table").GetComponent<Table>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startText.startFlag == true)
        {
            // 処理しなくなった時が目的地
            if (Enter())
            {
                MoveX();
                MoveZ();
            }
           // Debug.Log(this.gameObject.transform.position);

            // 到着したらposFlagをtrueにする
            if (poszFlag == true && posxFlag == true)
            {
                Angle();
                updateFlag = true;
            }
        }
    }
    bool Enter()
    {
        if(this.gameObject.transform.position.z <= 45)
        {
            return true;
        }
        this.gameObject.transform.Translate(0, 0, 0.05f);
        return false;
    }
    void MoveX()
    {
        if (!posxFlag)
        {
            if (this.gameObject.transform.position.x < chair.gameObject.transform.position.x)
            {

                this.gameObject.transform.Translate(-0.05f, 0, 0);
                posxFlag = false;

            }
            if (this.gameObject.transform.position.x > chair.gameObject.transform.position.x)
            {
                this.gameObject.transform.Translate(0.05f, 0, 0);
                posxFlag = false;
            }
        }

        // 0.01以下なら止まった判定
        float XDiff = Mathf.Abs(chair.gameObject.transform.position.x - this.gameObject.transform.position.x);
        if (XDiff <= 0.05f)
        {
            posxFlag = true;
        }

    }

    void MoveZ()
    {
        if (!poszFlag)
        {
            if (this.gameObject.transform.position.z < chair.gameObject.transform.position.z)
            {
                this.gameObject.transform.Translate(0, 0, -0.05f);
                poszFlag = false;
            }
            if (this.gameObject.transform.position.z > chair.gameObject.transform.position.z)
            {
                this.gameObject.transform.Translate(0, 0, 0.05f);
                poszFlag = false;
            }
        }
        float ZDiff = Mathf.Abs(chair.gameObject.transform.position.z - this.gameObject.transform.position.z);
        if (ZDiff <= 0.05f)
        {
            poszFlag = true;
        }
    }

    void Angle()
    {
        if (!updateFlag)
        {
            Vector2 visitorPos = new Vector2(this.transform.position.x, this.transform.position.z); // 自分の座標(Vec2)
            Vector2 tablePos = new Vector2(table.transform.position.x, table.transform.position.z);

            Vector2 anglePos = tablePos - visitorPos;
            float angle = Mathf.Atan2(anglePos.y, anglePos.x) * Mathf.Rad2Deg;
            angle = Mathf.Abs(angle);
            this.transform.Rotate(0, angle - 90.0f, 0);
        }
    }
}
