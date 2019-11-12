using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiSpone : MonoBehaviour
{
    private SushiRundom random;
    private bool randStart;         //乱数を取るかどうかのフラグ
    private int nextObjNum;         //次回の種別

    //寿司モデルのプレハブリスト
    private List<GameObject> sushiObjList;
    private List<int> sushiCount;
    private int totalCnt;
    Object[] sushiObj;

    //スポーン用変数
    [SerializeField]
    private int spTimeSecond = default;         //スポーンする間隔（秒）
    private float flamNum;                      //フレーム数
    [SerializeField]
    private int maxSponeCnt = default;

    private void Start()
    {
        //Resourcesフォルダ内のprefabフォルダ内の全てのプレハブを取得
        sushiObj = Resources.LoadAll("prefab/neta/");
        sushiObjList = new List<GameObject>();
        sushiCount = new List<int>();
        foreach (GameObject obj in sushiObj)
        {
            sushiCount.Add(0);
            sushiObjList.Add(obj);
        }
        random = GameObject.FindGameObjectWithTag("Random").GetComponent<SushiRundom>();
        randStart = false;
        nextObjNum = random.GetRandom(sushiObjList.Count);
        flamNum = 0f;
        totalCnt = 0;
    }

    private void Update()
    {
        if (randStart)
        {
            //次出現させる寿司を決めておく
            nextObjNum = random.GetRandom(sushiObjList.Count);
            randStart = false;
        }
        flamNum += Time.deltaTime;
        //フレーム数が指定した間隔になればスポーンor注文させる
        if (spTimeSecond <= flamNum)
        {
            totalCnt++;
            if (totalCnt <= maxSponeCnt)
            {
                //指定オブジェクトスポーン
                GameObject obj = Instantiate<GameObject>(sushiObjList[nextObjNum], this.transform.position, Quaternion.Euler(-90, 0, 90));
                obj.name = sushiObj[nextObjNum].name;
                sushiCount[nextObjNum]++;
                randStart = true;
            }
            flamNum = 0;
        }

        // [Debug] 各種類の合計数を表示する
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int j = 0; j < sushiCount.Count; j++)
            {
                Debug.Log(sushiCount[j]);
            }
        }
    }

    //次落ちてくる寿司のオブジェクトを取得
    public GameObject GetNextSushi()
    {
        return sushiObjList[nextObjNum];
    }
}
