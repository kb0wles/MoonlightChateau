using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Strike_Counter : MonoBehaviour
{
    [SerializeField] List<Image> stikes = new List<Image>();

    private Image img;
    [SerializeField] Sprite newSprite;
    int strikepos;

    int strikes = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StrikeCounter()
    {
        strikes++;
        Debug.Log(strikes);
        changestrike();
    }

    void changestrike()
    {
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
}
