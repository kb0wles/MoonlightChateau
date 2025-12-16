using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalChoice : MonoBehaviour
{
    [SerializeField] GameObject img;
    [SerializeField] int suspectNum;

    public static FinalChoice Instance;
    public string charName;

    void Awake()
    {
        Instance = this;
    }
    public void ConfirmChoice()
    {
        img.SetActive(true);
        Debug.Log(suspectNum);
    }

    public void TurnOffChoice()
    {
        img.SetActive(false);
    }

    public void SetCharName(string _charName) 
    {
        charName = _charName;
    }

    public int getSuspectnum()
    {
        return suspectNum;
    }

    public void SetSuspect(int num)
    {
        suspectNum = num;
        ConfirmChoice();
    }

}
