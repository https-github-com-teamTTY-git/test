using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SushiOrder : MonoBehaviour
{
    private GameObject orderCanvas;
    private int orderObjNum;         //注文種別
    private bool orderFlag;          //注文フラグ
    private SushiRundom random;
    private int childCnt;

    //寿司モデルのプレハブリスト
    private List<GameObject> sushiObjList;
    private Object[] sushiObj;

    private void Start()
    {
        //Resourcesフォルダ内のprefabフォルダ内の全てのプレハブを取得
        sushiObj = Resources.LoadAll("prefab/neta/");
        sushiObjList = new List<GameObject>();
        foreach (GameObject obj in sushiObj)
        {
            sushiObjList.Add(obj);
        }
        childCnt = 0;
        orderObjNum = 0;
        orderFlag = false;
        random = GameObject.FindGameObjectWithTag("Random").GetComponent<SushiRundom>();
        orderCanvas = GameObject.FindGameObjectWithTag("Order");
    }

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Visitor")
        {
            orderFlag = true;
            Invoke("Order", 2.0f);
            orderObjNum = random.GetRandom(sushiObjList.Count);
            other.transform.GetChild(2).gameObject.tag = sushiObjList[orderObjNum].name;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Visitor")
        {
            childCnt = 0;
            for (int j = 0; j < 5; j++)
            {
                if (transform.parent.gameObject.transform.GetChild(j).name == gameObject.name)
                {
                    break;
                }
                childCnt++;
            }
            //オーダーする
            orderCanvas.transform.GetChild(childCnt).gameObject.SetActive(false);
            orderCanvas.transform.GetChild(childCnt).transform.GetChild(orderObjNum).gameObject.SetActive(false);
        }
    }

    private void Order()
    {
        //注文する
        if (orderFlag)
        {
            childCnt = 0;
            orderFlag = false;
            for(int j = 0; j < 5; j++)
            {
                if (transform.parent.gameObject.transform.GetChild(j).name == gameObject.name)
                {
                    break;
                }
                childCnt++;
            }
            //オーダーする
            orderCanvas.transform.GetChild(childCnt).gameObject.SetActive(true);
            orderCanvas.transform.GetChild(childCnt).transform.GetChild(orderObjNum).gameObject.SetActive(true);
            
        }
    }
}
