using UnityEngine;

public class WinLose : MonoBehaviour
{
    [SerializeField] GameObject txt;
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
        if (wincount >= 3 && txt.gameObject.activeSelf == false)
        {
            txt.gameObject.SetActive(true);
        }
    }

    void Lose()
    {
        //if (txt.gameObject.activeSelf == false)
        //{
        //    txt.gameObject.SetActive(true);
        //}
    }
}
