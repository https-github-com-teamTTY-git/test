using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiFall : MonoBehaviour
{
    SushiFallRundom sushiFallRundom = null;
    private bool randStart;         //乱数を取るかどうかのフラグ
    private int nextObjNum;         //次回の種別

    //寿司モデルのプレハブリスト
    private List<GameObject> sushiFallObjList;
    private List<int> sushiFallCount;
    private int totalCnt;

    //スポーン用変数
    [SerializeField]
    private int spTimeSecond = default;         //スポーンする間隔（秒）
    private float flamNum;                        //フレーム数
    [SerializeField]
    private int maxSponeCnt = default;
    //[SerializeField]
    //private int fallSpeed = default;
    [SerializeField]
    private Vector3 vec3 = new Vector3(0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        //Resourcesフォルダ内のprefabフォルダ内の全てのプレハブを取得
        Object[] sushiObj = Resources.LoadAll("prefab/neta/");
        sushiFallObjList = new List<GameObject>();
        sushiFallCount = new List<int>();
        foreach (GameObject obj in sushiObj)
        {
            sushiFallCount.Add(0);
            sushiFallObjList.Add(obj);
        }
        sushiFallRundom = this.GetComponent<SushiFallRundom>();
        randStart = false;
        nextObjNum = sushiFallRundom.GetRandom(sushiFallObjList.Count);
        flamNum = 0;
        totalCnt = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (randStart)
        {
            //次出現させる寿司を決めておく
            nextObjNum = sushiFallRundom.GetRandom(sushiFallObjList.Count);
            randStart = false;
        }

        flamNum += Time.deltaTime;
        //フレーム数が指定した間隔になればスポーンor注文させる
        if (flamNum >= spTimeSecond)
        {
            totalCnt++;
            if (totalCnt <= maxSponeCnt)
            {
                //指定オブジェクトスポーン
               // this.transform.position = sponeSushiPos[Random.Range(0, 4)];
                GameObject obj = Instantiate<GameObject>(sushiFallObjList[nextObjNum],this.transform.position, Quaternion.Euler(vec3));
                sushiFallCount[nextObjNum]++;
                randStart = true;
            }
            flamNum = 0;
        }

        // [Debug] 各種類の合計数を表示する
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int j = 0; j < sushiFallCount.Count; j++)
            {
                Debug.Log(sushiFallCount[j]);
            }
        }

    }

    //次落ちてくる寿司のオブジェクトを取得
    public GameObject GetNextSushi()
    {
        return sushiFallObjList[nextObjNum];
    }
}
