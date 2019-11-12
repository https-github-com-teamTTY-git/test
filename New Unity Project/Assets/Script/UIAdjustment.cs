using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAdjustment : MonoBehaviour
{
    private Vector2 screenSize;
    private CanvasScaler scaler;
    void Start()
    {
        screenSize = new Vector2(Screen.width, Screen.height);
        Debug.Log(screenSize);
        scaler = this.GetComponent<CanvasScaler>();
        scaler.referenceResolution = screenSize;
    }
}
