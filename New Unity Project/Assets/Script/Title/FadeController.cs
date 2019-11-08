using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    float fadeSpeed = 0.02f;        //透明度が変わるスピードを管理
    float red, green, blue, alfa;   //パネルの色、不透明度を管理

    //public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
    //public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ
    public bool isendFadeFlg = false;        // 終わったらtrue

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
        isendFadeFlg = false;
    }

    public bool StartFadeIn(){
		alfa -= fadeSpeed;                //a)不透明度を徐々に下げる
		SetAlpha ();                      //b)変更した不透明度パネルに反映する
		if(alfa <= 0.0f){                    //c)完全に透明になったら処理を抜ける
			fadeImage.enabled = false;    //d)パネルの表示をオフにする
            isendFadeFlg = true;
        }
        return isendFadeFlg;
    }
 
	public bool StartFadeOut(){
		fadeImage.enabled = true;  // a)パネルの表示をオンにする
		alfa +=  fadeSpeed;         // b)不透明度を徐々にあげる
        Debug.Log(alfa);
		SetAlpha ();               // c)変更した透明度をパネルに反映する
		if(alfa >= 1.0f){             // d)完全に不透明になったら処理を抜ける

            isendFadeFlg = true;
        }
        return isendFadeFlg;
    }

    void SetAlpha(){
		fadeImage.color = new Color(red, green, blue, alfa);
	}
}
