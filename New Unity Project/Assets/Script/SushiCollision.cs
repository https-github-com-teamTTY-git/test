using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiCollision : MonoBehaviour
{
    private VisitorCon audience;

    private ScoreMng score;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject Audience = GameObject.Find("Audience");
        //audience = Audience.GetComponent<VisitorCon>();
        audience = transform.parent.GetComponent<VisitorCon>();
        score = GameObject.Find("ScoreMng").GetComponent<ScoreMng>();
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
            if (myTag == collision.gameObject.tag)
            {
                score.AddScore();
                Destroy(collision.gameObject);// 衝突した方(寿司)のオブジェクトを破壊
                audience.Back();

            }
        }
    }


}
