﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartText : MonoBehaviour
{
    [SerializeField]
    float gameTime = 20.0f;        // ゲーム制限時間 [s]
    Text timeText;                   // UIText コンポーネント
    float currentTime;             // 残り時間タイマー
    public bool startFlag;
    private AudioSource seSound;
    private bool onceFlag;

    private FadeIn fadeIn;

    void Start()
    {
        fadeIn = GameObject.Find("Panel").GetComponent<FadeIn>();

        // Textコンポーネント取得
        timeText = GetComponent<Text>();
        // 残り時間を設定
        currentTime = gameTime;
        seSound = this.GetComponent<AudioSource>();
        onceFlag = true;
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

        if ((fadeIn.isendFadeFlg == true) && (6.0f <= currentTime))
        {
            timeText.text = "　よーい";
        }
        else if ((5.0f <= currentTime) && (currentTime < 6.0f))
        {
            timeText.text = "スタート！！";
            if (onceFlag)
            {
                seSound.Play();
                onceFlag = false;
            }
        }
        else
        {
            // スタートが消えないから文字を書かずに上書きする
            timeText.text = "";
        }


        // isendFadeFlgがtrueかつcurrentTimeが10以下から5以上の間
        if (currentTime <= 5.0f)
        {
            // currentTimeが120以下になったらstartFlagをtrueにしてタイマーがスタート
            startFlag = true;
        }


    }
}
