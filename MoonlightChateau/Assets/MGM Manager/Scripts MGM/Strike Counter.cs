using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class Strike_Counter : MonoBehaviour
{
    [SerializeField] List<Image> stikes = new List<Image>();

    private Image img;
    [SerializeField] Sprite newSprite;
    int strikepos;
    [SerializeField] int strikes;
    bool gameover, start;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StrikeCounter()
    {
        if (!gameover && start)
        {
            changestrike();
            Debug.Log(strikes);
        }
    }

    void changestrike()
    {
        if (Time.timeScale == 0) return; //if paused ignore clicks -kb 

        strikes++;
        if (strikes == 1)
        {
            img = stikes[strikepos];
            img.sprite = newSprite;
            strikepos++;
        }
        else if (strikes == 2)
        {
            img = stikes[strikepos];
            img.sprite = newSprite;
            strikepos++;
        }
        else if (strikes == 3)
        {
            img = stikes[strikepos];
            img.sprite = newSprite;
            strikepos++;
        }
    }
    public int GetStrikes()
    {
        return strikes;
    }

    public void OnGameOver()
    {
        gameover = true;
    }

    public void GameStart()
    {
        start = true;
        strikes = 0;
    }
}
