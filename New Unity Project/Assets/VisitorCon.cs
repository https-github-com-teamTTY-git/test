using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorCon : MonoBehaviour
{

    private Chair chair;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Chair_1");
        chair = obj.GetComponent<Chair>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.x < chair.gameObject.transform.position.x)
        {
            this.gameObject.transform.Translate(-0.05f, 0, 0);
        }
        if (this.gameObject.transform.position.x > chair.gameObject.transform.position.x)
        {
            this.gameObject.transform.Translate(0.05f, 0, 0);
        }
        if (this.gameObject.transform.position.z < chair.gameObject.transform.position.z)
        {
            this.gameObject.transform.Translate(0, 0, -0.05f);
        }
        if (this.gameObject.transform.position.z > chair.gameObject.transform.position.z)
        {
            this.gameObject.transform.Translate(0, 0, 0.05f);
        }
        Debug.Log(this.gameObject.transform.position);
    }
}
