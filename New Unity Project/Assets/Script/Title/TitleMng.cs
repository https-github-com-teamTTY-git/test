using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMng : MonoBehaviour
{
    [SerializeField]
    private GameObject lane = null;
    [SerializeField]
    private GameObject titleName = null;

    private TitleRotate rotateScr;
    private TitleName nameScr;

    void Start()
    {
        rotateScr = lane.GetComponent<TitleRotate>();
        nameScr = titleName.GetComponent<TitleName>();
    }

    private void Update()
    {
        rotateScr.RotateLane();
        nameScr.TitleNameMove();
    }
}
