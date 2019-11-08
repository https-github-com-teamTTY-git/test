﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private GameObject effectObj;

    private Vector3 sushiScale;
    private Quaternion rotate;
    private List<string> rideOnList;
    private bool destroyFlag;
    private GameObject parentObj;

    private void Start()
    {
        effectObj = GameObject.Find("Effect");  
        effectObj.transform.GetChild(0).transform.gameObject.SetActive(false);

        sushiScale = transform.lossyScale;
        rotate = transform.rotation;
        rideOnList = new List<string>();
        Object[] sushiObj = Resources.LoadAll("prefab");
        foreach (GameObject obj in sushiObj)
        {
            rideOnList.Add(obj.name);
        }
        rideOnList.Add("lane");
        rideOnList.Add("rice");
        destroyFlag = true;
        parentObj = GameObject.Find("DefaultRotaObj");
    }

    // 衝突した際に親子関係を持たせる
    void OnCollisionEnter(Collision collision)
    {
        // エフェクトの表示
        effectObj.transform.GetChild(0).transform.gameObject.SetActive(true);

        foreach (string name in rideOnList)
        {
            if(name == collision.gameObject.name)
            {
                destroyFlag = false;
                transform.parent = parentObj.transform;
                break;
            }
        }

        if (destroyFlag)
        {
            Destroy(this.transform.gameObject);
        }
    }
}
