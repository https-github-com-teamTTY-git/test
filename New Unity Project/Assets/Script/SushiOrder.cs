using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SushiOrder : MonoBehaviour
{
    SushiRundom sushiRundom = null;
    private int orderObjNum;         //注文種別
    [SerializeField]
    private bool orderFlag;          //注文フラグ
    

    //寿司モデルのプレハブリスト
    private List<GameObject> sushiObjList;
    private List<int> sushiCount;

    void Start()
    {
        //Resourcesフォルダ内のprefabフォルダ内の全てのプレハブを取得
        Object[] sushiObj = Resources.LoadAll("prefab/neta/");
        sushiObjList = new List<GameObject>();
        sushiCount = new List<int>();
        foreach (GameObject obj in sushiObj)
        {
            sushiCount.Add(0);
            sushiObjList.Add(obj);
        }
        sushiRundom = this.GetComponent<SushiRundom>();
        orderObjNum = 0;
        orderFlag = false;
    }

    void Update()
    {
        //注文する
        if(orderFlag)
        {
            orderObjNum = sushiRundom.GetRandom(sushiObjList.Count);
            orderFlag = false;
            //タグをつける
            //オーダーする
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(0).transform.GetChild(orderObjNum).gameObject.SetActive(true);
        }
    }
}
