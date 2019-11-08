using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    private Text finishText;
    private TimerMng timerMng;
    // Start is called before the first frame update
    void Start()
    {
        finishText = GetComponent<Text>();

        timerMng = GameObject.Find("TimerText").GetComponent<TimerMng>();


        // 数字で経過時間を決める
        Invoke("ChangeScene", 120f);

    }

    // Update is called once per frame
    void Update()
    {
        // タイムアップ後にfinish表示
        if (timerMng.TimerFlag == true)
        {
            finishText.text = "Finish!!";
        }

    }
    void ChangeScene()
    {
        SceneManager.LoadScene("ResultScene");
    }


}
