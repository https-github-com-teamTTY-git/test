using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluationCtl : MonoBehaviour
{
    [SerializeField]
    private GameObject MaruPanels = null;
    private Text evaluation;

    private int score;
    private int hanaScore = 2000;
    private int twoMaruScore = 1000;
    private int maruScore = 0;

    void Start()
    {
        score = ScoreMng.GetScore();
        evaluation = this.GetComponent<Text>();
    }

    void Update()
    {
        if(score >= hanaScore)
        {
            //はなまる
            evaluation.text = "にっこりえがお";
            MaruPanels.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(score >= twoMaruScore)
        {
            //◎
            evaluation.text = " 1000とっぱ ";
            MaruPanels.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if(score >= maruScore)
        {
            //〇
            evaluation.text = "  あめあられ";
            MaruPanels.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            //なし
            evaluation.text = " つぶれました ";
        }
    }
}
