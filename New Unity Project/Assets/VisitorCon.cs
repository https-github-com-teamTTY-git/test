using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorCon : MonoBehaviour
{
    CharacterController charaCon;
    float velocity = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        charaCon = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
