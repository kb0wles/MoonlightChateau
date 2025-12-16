using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
public class MinigameManger : MonoBehaviour
{

    public static MinigameManger Instance;

    [SerializeField] float startTime;
    public TMP_Text timerText;
    bool timeractive;

    public GameObject winpopup;
    public GameObject losepopup;

    [SerializeField] GameObject toturialGO;
    [SerializeField] float toturialTime = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        timeractive = true;
    }

    private void Start()
    {
        StartCoroutine(ShowToturial());
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    IEnumerator ShowToturial()
    {
        toturialGO.SetActive(true);

        yield return new WaitForSeconds(toturialTime);

        toturialGO.SetActive(false);
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
                timeractive = false;
                losepopup.SetActive(true);

                if (ManagerScene.Instance != null)
                {
                    GameManager.Instance.Lose();
                    FadeTransition.Instance.TriggerFadeIN();
                    ManagerScene.Instance.PlayLobbyScene();
                }
            }
        }
        
        timerText.text = startTime.ToString();

    }

    public void Timerdeactivate()
    {
        timeractive = false;
    }

    public bool getGameStatus()
    {
        return timeractive;
    }

}
