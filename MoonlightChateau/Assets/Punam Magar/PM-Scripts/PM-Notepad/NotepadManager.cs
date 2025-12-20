using UnityEngine;

public class NotepadManager : MonoBehaviour
{
    public static NotepadManager Instance;

    [SerializeField] private GameObject noteParent;
    [SerializeField] private GameObject noteSummaryPrefab;
    [SerializeField] private GameObject characterSelectionGO;
    [SerializeField] private GameObject child;

    CharacterProfile selectedCharacter;
    string summaryNoteText;

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

    public void AddNote() 
    {
        GameObject note = Instantiate(noteSummaryPrefab, noteParent.transform);
        SummaryNoteInfos summaryNoteInfos = note.GetComponent<SummaryNoteInfos>();

        summaryNoteInfos.characterImage.sprite = selectedCharacter.GetPortraitByEmotion(EmotionType.Neutral);
        summaryNoteInfos.characterName.text = selectedCharacter.characterName;
        summaryNoteInfos.noteSummary.text = summaryNoteText;

        ClearSelectedCharacter();
    }

    public void ClearAllNotes() 
    {
        foreach(Transform note in noteParent.transform) 
        {
            Destroy(note.gameObject);
        }
    }

    public void SetSelectedCharacter(CharacterProfile characterProfile) 
    {
        selectedCharacter = characterProfile;
    }

    public CharacterProfile GetSelectedCharacter() 
    {
        return selectedCharacter;
    }

    public void SetSummaryNoteText(string text) 
    {
        summaryNoteText = text;
    }

    public void ClearSelectedCharacter() 
    {
        selectedCharacter = null;
        summaryNoteText = "";
    }

    public void OnClickADD() 
    {
        characterSelectionGO.SetActive(true);
    }

    public void OnClickCloseNotepad() 
    {
        child.SetActive(false);
    }

    public void OnClickOpenNotepad() 
    {
        child.SetActive(true);
    }
}
