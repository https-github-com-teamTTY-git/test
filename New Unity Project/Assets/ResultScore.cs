using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI関連クラスを使用できるようにする
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    public Text textResultScore;

    void Update()
    {
        int score = ScoreMng.GetScore();
        if(score >= 1000)
        {
            textResultScore.text = "Score:" + score + "えん";
        }
        else if (score >= 100)
        {
            textResultScore.text = "Score:" + "   " + score + "えん";
        }
        else if (score >= 10)
        {
            textResultScore.text = "Score:" + "    " + score + "えん";
        }
        else if (score >= 0)
        {
            textResultScore.text = "Score:" + "    " + score + "えん";
        }
        else if (score >= -90)
        {
            textResultScore.text = "Score:" + "  " + score + "えん";
        }
        else
        {
            textResultScore.text = "Score:" + score + "えん";
        }
    }
}
