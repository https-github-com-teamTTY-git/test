using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    private bool isFadeOut = false;  // フェードアウト処理の開始、完了を管理するフラグ
   
    private FadeController fadeCtl;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Fade");   // 指定の名前のオブジェクトを探す(処理重い※update書込禁止)
        fadeCtl = obj.GetComponent<FadeController>();
        fadeCtl.isendFadeFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeOut)
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
