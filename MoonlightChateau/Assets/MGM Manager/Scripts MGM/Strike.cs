using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Strike : MonoBehaviour
{
    int numbertest = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StrikeCounter()
    {
        numbertest++;
        Debug.Log(numbertest);
    }

}
