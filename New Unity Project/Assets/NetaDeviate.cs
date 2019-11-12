using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetaDeviate : MonoBehaviour
{
    private ScoreMng score;
    private GameObject effectObj;

    private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        effectObj = GameObject.Find("Effect");
        effectObj.transform.GetChild(0).transform.gameObject.SetActive(false);

        score = GameObject.Find("ScoreMng").GetComponent<ScoreMng>();

    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HitLean");
        score.DeductionScore();
        // エフェクトの表示
        effectObj.transform.GetChild(0).transform.gameObject.SetActive(true);
        particle = effectObj.transform.GetChild(0).GetComponent<ParticleSystem>();
        particle.startColor = new Color(0,0,0);

        Destroy(collision.gameObject);// 衝突した方(寿司)のオブジェクトを破壊
    }

}
