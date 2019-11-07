using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnClick()
    {
        // ゲームシーンへ移動
        SceneManager.LoadScene("Scenes/GameScene");
        Debug.Log("ゲームシーンへ!");  // ログを出力
    }

}
