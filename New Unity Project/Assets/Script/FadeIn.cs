using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeIn : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed = 0.02f;        // 透明度が変わるスピードを管理

    private float red, green, blue, alfa;   // パネルの色、不透明度を管理

    private bool isendFadeFlg = false;      // 終わったらtrue
    private bool isFadeIn = false;          // フェードイン処理の開始、完了を管理するフラグ

    private Image fadeImage;                // 透明度を変更するパネルのイメージ

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        isFadeIn = true;
        if (isFadeIn)
        {
            // フェードインを行って、isendFadeFlgがtrueになったら終了する
            if (StartFadeIn())
            {
                isFadeIn = false;
                isendFadeFlg = false;
            }
        }
    }

    bool StartFadeIn()
    {
        alfa -= fadeSpeed;                // 不透明度を徐々に下げる
        SetAlpha();                       // 変更した不透明度パネルに反映する
        if (alfa <= 0.0f)
        {                                 // 完全に透明になったら処理を抜ける
            fadeImage.enabled = false;    // パネルの表示をオフにする
            isendFadeFlg = true;
        }
        return isendFadeFlg;              // 処理を終了するのでtrueにする
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
