using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBuckScript : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Scenes/TitleScene");
    }
}
