using UnityEngine;

public class PrevMinigameDialogueTracker : MonoBehaviour
{
    public static PrevMinigameDialogueTracker Instance;

    [Header("Win-Lose Dialogue")]

    [SerializeField] DialogueNode wonDialogue;
    [SerializeField] DialogueNode lostDialogue;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        if (GameManager.Instance.prevMiniGameResult == GameManager.MinigameStatus.Win)
        {
            DialogueManager.Instance.DisplayDialogue(wonDialogue);
        }
        else
        {
            DialogueManager.Instance.DisplayDialogue(lostDialogue);
        }
    }
}
