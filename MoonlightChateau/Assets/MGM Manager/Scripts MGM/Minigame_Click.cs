using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame_Click : MonoBehaviour
{

    public Color oldcolor;

    private Image img;

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
        img.color = Color.white;
    }
}
