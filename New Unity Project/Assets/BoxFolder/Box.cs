using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // 衝突した際に親子関係を持たせる
    void OnCollisionEnter(Collision collision)
    {
        transform.parent = GameObject.Find("lane").transform;
    }
}
