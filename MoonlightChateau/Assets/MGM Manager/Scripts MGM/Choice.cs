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
        choiceID = FinalChoice.Instance.getSuspectnum();
        Debug.Log(choiceID);
        if (choiceID == correct)
        {
            // load true ending
        }
        else if (choiceID != correct)
        {
            // load mistake ending
        }
    }

    public void ClickNo()
    {
        FinalChoice.Instance.TurnOffChoice();
    }
}
