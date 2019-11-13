using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiCollision : MonoBehaviour
{
    private VisitorCon audience;

    private ScoreMng score;
    private AudioSource[] seSounds;

    void Start()
    {
        audience = transform.parent.GetComponent<VisitorCon>();
        score = GameObject.Find("ScoreMng").GetComponent<ScoreMng>();
        seSounds = GameObject.FindGameObjectWithTag("SEMng").GetComponents<AudioSource>();
    }

    void OnTriggerStay(Collider collision)// triggerがあるときはこれ
    {
        string myTag = gameObject.tag;    // 自分自身のタグ

        if (audience.updateFlag == true)
        {
            if (myTag == collision.gameObject.tag)
            {
                seSounds[0].Play();
                score.AddScore();
                Destroy(collision.gameObject);// 衝突した方(寿司)のオブジェクトを破壊
                audience.Back();

            }
        }
    }


}
