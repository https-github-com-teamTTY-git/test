using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRotate : MonoBehaviour
{
    private Quaternion angle;
    // Start is called before the first frame update
    void Start()
    {
        angle = this.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, 0.5f);
    }
}
