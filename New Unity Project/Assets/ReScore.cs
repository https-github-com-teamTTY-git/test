using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI関連クラスを使用できるようにする
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class ReScore : MonoBehaviour
{
    //// UIオブジェクト"Text Score"のTextコンポーネントを格納する変数
    //public Text textScore;
    // UIオブジェクト"Text ResultScore"Textコンポーネントを格納する変数
    public Text textResultScore;
   
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        int score = ScoreMng.GetScore();
        textResultScore.text = "Score: " + score+"円";


    }
}
