using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerMng : MonoBehaviour
{
    [SerializeField]
    float gameTime = 20.0f;        // ゲーム制限時間 [s]
    Text timeText;                   // UIText コンポーネント
    float currentTime;             // 残り時間タイマー
    public bool TimerFlag;


    // Start is called before the first frame update
    void Start()
    {
        // Textコンポーネント取得
        timeText = GetComponent<Text>();
        // 残り時間を設定
        currentTime = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        // 残り時間を計算する
        currentTime -= Time.deltaTime;

        // ゼロ秒以下にならないようにする
        if (currentTime <= 0.0f)
        {
            currentTime = 0.0f;
        }
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        int mseconds = Mathf.FloorToInt((currentTime - minutes * 60 - seconds) * 1000);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (115.0f >= currentTime)
        {
            TimerFlag = true;
        }

    }
}
