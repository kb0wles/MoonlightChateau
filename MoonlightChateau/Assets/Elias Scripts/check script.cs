using UnityEngine;
using UnityEngine.UI;

public class checkscript : MonoBehaviour
{
    [SerializeField] Image Check;
    [SerializeField] Minigame_Click clickable;
    float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(clickable.img.color != clickable.oldcolor)
        {
            checkoff();
        }
    }

    void checkoff()
    {
        Check.gameObject.SetActive(true);
    }
}
