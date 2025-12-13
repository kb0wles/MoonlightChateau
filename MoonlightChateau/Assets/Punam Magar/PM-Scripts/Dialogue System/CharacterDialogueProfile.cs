using UnityEngine;

public class CharacterDialogueProfile : MonoBehaviour
{
    [Header("Main Dialogues")]
    [SerializeField] DialogueNode startNode;
    [SerializeField] DialogueNode endNode;

    [Header("Loop Dialogues")]
    [SerializeField] DialogueNode loopNode;

    public void PlayDialogue() 
    {
        if (startNode != null)
        {
            DialogueManager.Instance.UpdateDialogueSettings(this);
            DialogueManager.Instance.DisplayDialogue(startNode);
        }
    }

    private void Start()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.UpdateCharacterInScene(1);
        }
    }

    public DialogueNode GetStartNode() 
    {
        return startNode;
    }

    public DialogueNode GetEndNode() 
    {
        return endNode;
    }

    public DialogueNode GetLoopNode() 
    {
        return loopNode;
    }

    public void SetLoop() 
    {
        startNode = loopNode;
    }
}
