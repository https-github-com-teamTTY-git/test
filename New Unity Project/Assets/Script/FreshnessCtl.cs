using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreshnessCtl : MonoBehaviour
{
    [SerializeField]
    private int freshnessSnd = default;
    private float flam;
    private Material mat;
    private 

    void Start()
    {
        flam = 0;
        string objName = this.transform.gameObject.name;
        mat = Resources.Load("material/" + objName + "2") as Material;
    }

    void FixedUpdate()
    {
        flam += Time.deltaTime;
        //鮮度が半減したら青くさせる
        if ((freshnessSnd - 5) < flam)
        {
            this.GetComponent<Renderer>().material = mat;
        }
        //鮮度が完全に落ちたら消去する
        if (freshnessSnd < flam)
        {
            Destroy(this.gameObject);
        }
    }
}
