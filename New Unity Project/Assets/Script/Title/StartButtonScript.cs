using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
   bool isFadeOut = false;         //フェードアウト処理の開始、完了を管理するフラグ
   bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ

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
                // fadeInする
                isFadeOut = false;
                //isFadeIn = true;
                fadeCtl.isendFadeFlg = false;
                // ゲームシーンへ
                SceneManager.LoadScene("Scenes/GameScene");

            }
        }

        // fadeInのreturnでisendFadeFlgがtrueになったとき
        // GameSceneで新しくパネルをつかってやったほうがいい
        //if(isFadeIn)
        //{
        //    if (fadeCtl.StartFadeIn())
        //    {
        //        isFadeIn = false;
        //        // ゲームシーンへ
        //        SceneManager.LoadScene("Scenes/GameScene");
        //    }
        //}
    }

    public void OnClick()
    {
        // fadeOutする
        isFadeOut = true;
    }
}
