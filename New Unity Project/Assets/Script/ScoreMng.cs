using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreMng : MonoBehaviour
{
    [SerializeField]
    public Text scoreText; //Text用変数
    public static int score = 0; //スコア計算用変数
                                  // staticつけたからタイトルで初期化しようぜ　リザルトで使える


    void Start()
    {
        scoreText.GetComponent<Text>();
        score = 0;
        SetScore();   //初期スコアを代入して表示
    }

    // スコア加点
    public void AddScore()
    {
        score += 150;
        //Debug.Log("プラス150えん");
        SetScore();
    }

    // スコア減点
    public void DeductionScore()
    {
        score -= 20;
        //Debug.Log("マイナス20えん");
        SetScore();
    }

    void SetScore()
    {
        scoreText.text = "Score:" + score + "えん";
    }

    public static int GetScore()
    {
        return score;
    }
}
