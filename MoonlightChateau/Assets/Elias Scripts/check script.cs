using UnityEngine;
using UnityEngine.UI;

public class CheckScript : MonoBehaviour
{
    [SerializeField] Image Check;
    [SerializeField] Minigame_Click clickable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (clickable.img.color != clickable.oldcolor)
        {
            checkoff();
        }
    }

    void checkoff()
    {
        Check.gameObject.SetActive(true);
    }
}
