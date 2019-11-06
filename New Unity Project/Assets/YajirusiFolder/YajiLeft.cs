using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YajiLeft : MonoBehaviour
{
    private Lane laneTest;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("lane");   // 指定の名前のオブジェクトを探す(処理重い※update書込禁止)
        laneTest = obj.GetComponent<Lane>();
    }

    // Update is called once per frame
    void Update()
    {
        if(laneTest.leftFlag)
        {
            MeshRenderer meshrender = GetComponent<MeshRenderer>();
            meshrender.material.color = new Color(255, 0, 0, 1.0f);
        }
        else
        {
            MeshRenderer meshrender = GetComponent<MeshRenderer>();
            meshrender.material.color = new Color(255, 0, 0, 0.3f);
        }
    }
}
