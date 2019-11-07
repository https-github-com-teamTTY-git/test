using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI関連クラスを使用できるようにする
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    public Text textResultScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        int score = ScoreMng.GetScore();
        textResultScore.text = "Score:" + score + "えん";

    }
}
