using System.Collections.Generic;
using UnityEngine;

public class Suspectnum : MonoBehaviour
{
    List<int> suspectnums;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getnum()
    {
        FinalChoice.Instance.getSuspectnum();
    }

}
