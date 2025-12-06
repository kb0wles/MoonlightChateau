using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MinigameManger : MonoBehaviour
{
    [SerializeField] float startTime;
    public TMP_Text timerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        if(startTime > 0)
        {
            startTime -= Time.deltaTime;
        }
        else if (startTime <= 0)
        {
            startTime = 0;
        }
        
        timerText.text = startTime.ToString();

    }

}
