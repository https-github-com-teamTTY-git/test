using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChairMng : MonoBehaviour
{
    Chair[] chair=new Chair[5];

    private bool[] sitFlag = new bool[5];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < 5;i++)
        {
            string _string = String.Format($"Chair_{i + 1}");
            chair[i] = GameObject.Find(_string).GetComponent<Chair>();
            sitFlag[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] visitors = GameObject.FindGameObjectsWithTag("Visitor");
        for (int i = 0; i < 5; i++)
        {
            sitFlag[i] = false;
            foreach (GameObject visitor in visitors)
            {
                VisitorCon obj = visitor.GetComponent<VisitorCon>();
                if (chair[i].name == obj.GetDestination())
                {
                    sitFlag[i] = true;
                }
            }
        }
    }
    //席が空いていたらtrue
    public bool CheckChair()
    {
        for(int i=0;i < 5;i++)
        {
            if(!sitFlag[i])
            {
                return true;
            }
        }
        return false;
    }
    //空いている席を確認
    public string vacancy()
    {
        string _string;
        if(!CheckChair())
        {
            return null;
        }
        for(int i=0;i<5; i++)
        {
            if(!sitFlag[i])
            {
                return _string = chair[i].name;
            }
        }
        return null;
    }
}
