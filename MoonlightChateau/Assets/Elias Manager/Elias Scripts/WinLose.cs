using UnityEngine;

public class WinLose : MonoBehaviour
{
    public static WinLose instance;

    [SerializeField] GameObject win;
    [SerializeField] GameObject lose;
    [SerializeField] Strike_Counter strikes;
    public int wincount;
    public static bool PauseGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
        PauseGame = false;
        wincount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseGame && !UIManager.instance.isPaused)
        {
            Win();
            Lose();
        }
        else
        {
           Debug.Log("Gameover / Paused");
            return;
        }
    }

    void Win()
    {
        if (wincount >= 3 && win.gameObject.activeSelf == false && lose.gameObject.activeSelf == false)
        {
            win.gameObject.SetActive(true);
            PauseGame = true;
            strikes.OnGameOver();
            GameManager.Instance.Win();
        }
    }

    void Lose()
    {
        if (strikes.GetStrikes() >= 3 && win.gameObject.activeSelf == false && lose.gameObject.activeSelf == false)
        {
            lose.gameObject.SetActive(true);
            PauseGame = true;
            strikes.OnGameOver();
            GameManager.Instance.Lose();
        }
    }

    public bool getGameStatus()
    {
        return PauseGame;
    }

}
