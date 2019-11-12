using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    private bool isFadeOut = false;  // フェードアウト処理の開始、完了を管理するフラグ
    
    private FadeController fadeCtl;
    private GameObject fade;

    void Start()
    {
        fade = GameObject.FindGameObjectWithTag("FadeObj");   // 指定の名前のオブジェクトを探す(処理重い※update書込禁止)
        fadeCtl = fade.GetComponent<FadeController>();
        fadeCtl.isendFadeFlg = false;
    }

    private void Update()
    {
        if (isFadeOut)
        {
            // fadeOutのreturnでisendFadeFlgがtrueになったとき
            if (fadeCtl.StartFadeOut())
            {
                // フェードアウト終了→シーン遷移
                isFadeOut = false;
                fadeCtl.isendFadeFlg = false;
                SceneManager.LoadScene("Scenes/GameScene");
            }
        }
    }

    public void OnClick()
    {
        // fadeOutする
        isFadeOut = true;
    }
}
