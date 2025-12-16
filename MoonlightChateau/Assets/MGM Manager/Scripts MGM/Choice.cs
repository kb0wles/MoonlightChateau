using UnityEngine;
using UnityEngine.SceneManagement;
public class Choice : MonoBehaviour
{
    int correct = 2;
    public int choiceID;
    string charName;

    ScenesStatus.SceneType nextSceneToLoad;

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
        charName = FinalChoice.Instance.charName;

        switch(charName)
        {
            case "Fox":
                ManagerScene.Instance.PlayFoxFE();
                break;
            case "Bear":
                ManagerScene.Instance.PlayBearFE();
                break;
            case "Rabbit":
                ManagerScene.Instance.PlayRabbitGE();
                break;
            default:
                break;
        }

        Debug.Log(choiceID);
        if (choiceID == correct)
        {
            // load true ending
        }
        else if (choiceID != correct)
        {
            // load mistake ending
        }

        ManagerScene.Instance.PlaySpecificScene(nextSceneToLoad);
    }

    public void ClickNo()
    {
        FinalChoice.Instance.TurnOffChoice();
    }
}
