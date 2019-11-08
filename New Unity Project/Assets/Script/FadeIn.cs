using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeIn : MonoBehaviour
{
    float fadeSpeed = 0.02f;        //透明度が変わるスピードを管理
    float red, green, blue, alfa;   //パネルの色、不透明度を管理

    bool isendFadeFlg = false;        // 終わったらtrue
    bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ


    Image fadeImage;                //透明度を変更するパネルのイメージ

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
        //GetComponent<Image>().enabled = true; //オフにしていたPanelのImageコンポーネントをオンに変更
        //GetComponent<Image>().color = new Color(255, 0, 0, 0.5f);　//Imageのカラーを変更。Colorの引数は（ 赤, 緑, 青, 不透明度 ）の順で指定
        if (isFadeIn)
        {
            if (StartFadeIn())
            {
                isFadeIn = false;
                isendFadeFlg = false;
            }
        }
    }

    public bool StartFadeIn()
    {
        alfa -= fadeSpeed;                //a)不透明度を徐々に下げる
        SetAlpha();                      //b)変更した不透明度パネルに反映する
        if (alfa <= 0.0f)
        {                    //c)完全に透明になったら処理を抜ける
            fadeImage.enabled = false;    //d)パネルの表示をオフにする
            isendFadeFlg = true;
        }
        return isendFadeFlg;
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }

    void OnActiveSceneChanged()
    {
        isFadeIn = true;
    }
}
