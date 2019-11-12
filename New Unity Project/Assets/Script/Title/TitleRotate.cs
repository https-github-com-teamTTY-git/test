using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRotate : MonoBehaviour
{
    private float rotaSpeed;

    void Start()
    {
        rotaSpeed = 0.5f;
    }

    public void RotateLane()
    {
        this.transform.Rotate(0, 0, rotaSpeed);
    }
}
