using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleName : MonoBehaviour
{
    private float speed;
    void Start()
    {
        speed = 0.01f;
    }

    public void TitleNameMove()
    {
        if (this.GetComponent<Image>().fillAmount < 1)
        {
            this.GetComponent<Image>().fillAmount += speed;
        }
    }
}
