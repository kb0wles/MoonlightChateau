using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MinigameManger : MonoBehaviour
{

    public static MinigameManger Instance;

    [SerializeField] float startTime;
    public TMP_Text timerText;
    bool timeractive;

    public GameObject winpopup;
    public GameObject losepopup;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        timeractive = true;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        if(timeractive)
        {
            if(startTime > 0)
            {
                startTime -= Time.deltaTime;
            }
            else if (startTime <= 0)
            {
                startTime = 0;
            }
        }
        
        timerText.text = startTime.ToString();

    }

    public void Timerdeactivate()
    {
        timeractive = false;
    }



}
