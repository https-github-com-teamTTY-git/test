using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SushiOrder : MonoBehaviour
{
    private int orderObjNum;         //注文種別
    private bool orderFlag;          //注文フラグ
    private SushiRundom random;

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
        orderObjNum = 0;
        orderFlag = false;
        random = GameObject.FindGameObjectWithTag("Random").GetComponent<SushiRundom>();
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

    private void Order()
    {
        //注文する
        if (orderFlag)
        {
            orderFlag = false;
            //オーダーする
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(0).transform.GetChild(orderObjNum).gameObject.SetActive(true);
        }
    }
}
