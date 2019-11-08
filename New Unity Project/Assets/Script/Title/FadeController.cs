using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed = 0.02f;         // 透明度が変わるスピードを管理

    private float red, green, blue, alfa;    // パネルの色、不透明度を管理

    public bool isendFadeFlg = false;        // 終わったらtrue

    private Image fadeImage;                 // 透明度を変更するパネルのイメージ

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
 
	public bool StartFadeOut(){
		fadeImage.enabled = true;         // パネルの表示をオンにする
		alfa +=  fadeSpeed;               // 不透明度を徐々にあげる
		SetAlpha ();                      // 変更した透明度をパネルに反映する
		if(alfa >= 1.0f){                 // 完全に不透明になったら処理を抜ける

            isendFadeFlg = true;          // 処理を終了するのでtrueにする
        }
        return isendFadeFlg;
    }

    void SetAlpha(){
		fadeImage.color = new Color(red, green, blue, alfa);
	}
}
