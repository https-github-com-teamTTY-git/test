using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreMng : MonoBehaviour
{
    [SerializeField]
    public Text scoreText; //Text用変数
    private static int score = 0; //スコア計算用変数
                                  // staticつけたからタイトルで初期化しようぜ　リザルトで使える

    private VisitorCon audience;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.GetComponent<Text>();
        score = 0;
        SetScore();   //初期スコアを代入して表示

        // audienceが止まって寿司があたった時に消えるからその時にスコア加算
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
            if (myTag == collision.gameObject.tag)
            {
                score += 150;
                Debug.Log("collision[score+150]");
            }
        }
        SetScore();
    }


    void SetScore()
    {
        scoreText.text = string.Format("Score:{0}円", score);
    }
}
