using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleName : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        if (this.GetComponent<Image>().fillAmount < 1)
        {
            this.GetComponent<Image>().fillAmount += 0.01f;
        }
    }
}
