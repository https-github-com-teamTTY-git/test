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
    private int flamNum;                        //フレーム数
    private int flamSecond = 60;                //1秒間のフレーム数
    [SerializeField]
    private int maxSponeCnt = default;
    //[SerializeField]
    //private int fallSpeed = default;
    [SerializeField]
    private Vector3 vec3 = new Vector3(0, 0, 0);

    //private Vector3[] sponeSushiPos =
    //            {
    //                    new Vector3(-4,15,13),
    //                    new Vector3( 0,15,13),
    //                    new Vector3( 5,15,13),
    //                    new Vector3(-9,15,13),
    //                    new Vector3(10,15,13)
    //                };
    //private int[] fallSpeed =
    //{
    //    1,2,3,
    //};

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

        flamNum++;
        //フレーム数が指定した間隔になればスポーンor注文させる
        if (flamNum % (spTimeSecond * flamSecond) == 0)
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
