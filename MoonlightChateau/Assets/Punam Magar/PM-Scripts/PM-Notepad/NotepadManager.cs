using UnityEngine;

public class NotepadManager : MonoBehaviour
{
    public static NotepadManager Instance;

    [SerializeField] private GameObject noteParent;
    [SerializeField] private GameObject noteSummaryPrefab;

    private void Awake()
    {
        //create a singleton instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void AddSummaryNote() 
    {
        GameObject note = Instantiate(noteSummaryPrefab, noteParent.transform);
        SummaryNoteInfos summaryNoteInfos = note.GetComponent<SummaryNoteInfos>();

        summaryNoteInfos.characterImage.sprite = DialogueManager.Instance.currentDialougeNode.character.GetPortraitByEmotion(EmotionType.Neutral);
        summaryNoteInfos.characterName.text = DialogueManager.Instance.currentDialougeNode.character.characterName;
        summaryNoteInfos.noteSummary.text = DialogueManager.Instance.currentDialougeNode.GetSummaryNote();

    }
}
