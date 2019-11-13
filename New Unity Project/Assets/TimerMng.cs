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
    private AudioSource[] seSounds;
    private bool onceFlag;

    private StartText startText;

    // Start is called before the first frame update
    void Start()
    {
        startText = GameObject.Find("StartText").GetComponent<StartText>();
        seSounds = GameObject.FindGameObjectWithTag("SEMng").GetComponents<AudioSource>();
        // Textコンポーネント取得
        timeText = GetComponent<Text>();
        // 残り時間を設定
        currentTime = gameTime;
        onceFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startText.startFlag == true)
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
            timeText.text = string.Format("のこり "+"{0:00}:{1:00}", minutes, seconds);

            if (0.1f >= currentTime)
            {
                if (onceFlag)
                {
                    TimerFlag = true;
                    onceFlag = false;
                }
                seSounds[2].Play();
            }
        }
    }
}
