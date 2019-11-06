using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField]
    int a = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 衝突した際に親子関係を持たせる
    void OnCollisionEnter(Collision collision)
    {
        transform.parent = GameObject.Find("lane").transform;
    }
}
