using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalChoice : MonoBehaviour
{
    [SerializeField] GameObject img;
    [SerializeField] int suspectNum; 

    public void ConfirmChoice()
    {
        img.SetActive(true);
        Debug.Log(suspectNum);
    }

    public int getSuspectnum()
    {
        return suspectNum;
    }


}
