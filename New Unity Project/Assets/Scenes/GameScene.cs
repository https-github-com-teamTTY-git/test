using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    protected static int Score = 0;


    // Start is called before the first frame update
    void Start()
    {
        // 数字で経過時間を決める
        Invoke("ChangeScene", 10.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("ResultScene");
    }


}
