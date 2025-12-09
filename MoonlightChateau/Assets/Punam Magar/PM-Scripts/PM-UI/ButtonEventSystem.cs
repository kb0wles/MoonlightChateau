using System;
using UnityEngine;
using UnityEngine.Events;

public class ButtonEventSystem : MonoBehaviour
{
    public enum ButtonEventType
    {
        DialogueEnd,
        BackToScene,
    }

    [SerializeField] ButtonEventType buttonEventType;

    [SerializeField] GameObject changeSceneBTN;
    [SerializeField] GameObject endDialogueBTN;

    private void OnEnable()
    {
        switch (buttonEventType)
        {
            case ButtonEventType.DialogueEnd:
                GameManager.OnDialogueEnd += EnableEndDialogueBTN;
                break;

            case ButtonEventType.BackToScene:
                GameManager.OnCanPlayEnding += EnableChangeSceneBTN;
                break;
        }
    }

    private void OnDisable()
    {
        switch (buttonEventType)
        {
            case ButtonEventType.DialogueEnd:
                GameManager.OnDialogueEnd -= EnableEndDialogueBTN;
                break;

            case ButtonEventType.BackToScene:
                GameManager.OnCanPlayEnding -= EnableChangeSceneBTN;
                break;
        }
    }

    private void OnDestroy()
    {
        switch (buttonEventType)
        {
            case ButtonEventType.DialogueEnd:
                GameManager.OnDialogueEnd -= EnableEndDialogueBTN;
                break;

            case ButtonEventType.BackToScene:
                GameManager.OnCanPlayEnding -= EnableChangeSceneBTN;
                break;
        }
    }

    void EnableChangeSceneBTN()
    {
        changeSceneBTN.SetActive(true);
    }

    void EnableEndDialogueBTN()
    {
        endDialogueBTN.SetActive(true);
    }

    public void OnPlayEnding() 
    {
        GameManager.Instance.PlayEnding();
    }
}
