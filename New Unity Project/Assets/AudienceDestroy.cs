using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceDestroy : MonoBehaviour
{
    void OnTriggerStay(Collider collider)
    {
        Destroy(collider.gameObject);// 衝突した方(寿司)のオブジェクトを破壊
    }
}
