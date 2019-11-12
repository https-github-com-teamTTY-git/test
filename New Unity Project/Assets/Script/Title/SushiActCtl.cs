using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiActCtl : MonoBehaviour
{
    private int childObjCnt = 3;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SushiSet")
        {
            for (int j = 0; j < childObjCnt; j++)
            {
                other.transform.GetChild(j).gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SushiSet")
        {
            for(int j = 0; j < childObjCnt; j++)
            {
                other.transform.GetChild(j).gameObject.SetActive(false);
            }
        }
    }
}
