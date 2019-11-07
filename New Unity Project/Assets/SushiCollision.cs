using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiCollision : MonoBehaviour
{
    private VisitorCon audience;


    // Start is called before the first frame update
    void Start()
    {
        GameObject Audience = GameObject.Find("Audience5");
        audience = Audience.GetComponent<VisitorCon>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider collision)// triggerがあるときはこれ
    {
        string myTag = gameObject.tag;    // 自分自身のタグ

        if (audience.updateFlag == true)
        {
            Debug.Log("collisionnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn");
            if (myTag == collision.gameObject.tag)
            {

                Debug.Log("衝突したオブジェクト：" + gameObject.name);// 当たり判定
                Debug.Log("衝突されたオブジェクト：" + collision.gameObject.name);//寿司

                Destroy(collision.gameObject);// 衝突した方(寿司)のオブジェクトを破壊
            }
        }

    }


}
