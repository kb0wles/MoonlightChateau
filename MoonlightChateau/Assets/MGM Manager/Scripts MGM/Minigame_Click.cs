using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame_Click : MonoBehaviour
{
    [SerializeField] bool TFcheck;
    [SerializeField] Strike_Counter strikes;

    public Color oldcolor;

    public Image img;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        img = GetComponent<Image>();

        oldcolor = img.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorChange()
    {
        if (TFcheck == true)
        {
            img.color = Color.green;
        }
        else
        {
            strikes.StrikeCounter();
            img.color = Color.red;
        }
    }
}
