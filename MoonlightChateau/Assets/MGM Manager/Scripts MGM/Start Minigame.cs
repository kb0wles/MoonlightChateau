using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMinigame : MonoBehaviour
{

    //StartMinigame instance;
    //public Button startbutton;
    [SerializeField] GameObject startmenu;
    //public bool start;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //instance = this;
    }

    // Update is called once per frame
    void Start()
    {
        //start = false;
    }

    public void BeginMinigame()
    {
        //start = true;
        Destroy(startmenu);
    }

}
