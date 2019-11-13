using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    private Text finishText;
    private TimerMng timerMng;

    void Start()
    {
        finishText = GetComponent<Text>();

        timerMng = GameObject.FindGameObjectWithTag("TimerText").GetComponent<TimerMng>();

        // 数字で経過時間を決める
        Invoke("ChangeScene", 130.0f);
    }

    void Update()
    {

        // タイムアップ後にfinish表示
        if (timerMng.TimerFlag == true)
        {
            finishText.text = "そこまで！！";
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("ResultScene");
    }


}
