﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiFallCollision : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerStay(Collider collider)
    {
        Destroy(collider.gameObject);// 衝突した方(寿司)のオブジェクトを破壊
    }


}
