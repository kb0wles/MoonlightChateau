using UnityEngine;
using UnityEngine.SceneManagement;
public class Choice : MonoBehaviour
{
    int correct = 2;
    public int choiceID;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickYes()
    {
        FinalChoice.Instance.SetSuspect(choiceID);
        int check = FinalChoice.Instance.getSuspectnum();
        Debug.Log(check);
        if (check == correct)
        {
            // load true ending
        }
        else if (check != correct)
        {
            // load mistake ending
        }
    }

    public void ClickNo()
    {
        FinalChoice.Instance.TurnOffChoice();
    }
}
