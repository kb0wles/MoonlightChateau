using UnityEngine;

public class WinLose : MonoBehaviour
{
    [SerializeField] GameObject win;
    [SerializeField] GameObject lose;
    [SerializeField] Strike_Counter strikes;
    public int wincount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wincount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Win();
        Lose();
    }

    void Win()
    {
        if (wincount >= 3 && win.gameObject.activeSelf == false && lose.gameObject.activeSelf == false)
        {
            win.gameObject.SetActive(true);
        }
    }

    void Lose()
    {
        if (strikes.GetStrikes() >= 3 && win.gameObject.activeSelf == false && lose.gameObject.activeSelf == false)
        {
            lose.gameObject.SetActive(true);
        }
    }
}
