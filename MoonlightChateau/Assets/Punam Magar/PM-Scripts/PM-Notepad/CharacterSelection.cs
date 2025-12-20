using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] GameObject CharacterSeletionGO;
    [SerializeField] GameObject warningGO;
    [SerializeField] TMP_InputField notesTXT;

    [SerializeField] float warningDuration = 2f;

    public void OnClickDone() 
    {
        //check if character is selected
        if(NotepadManager.Instance.GetSelectedCharacter() == null || notesTXT.text == "") 
        {
            warningGO.SetActive(true);
            return;
        }

        //stop coroutine if character is selected
        if (NotepadManager.Instance.GetSelectedCharacter() != null && notesTXT.text != "" && warningGO.activeSelf)
        {
            warningGO.SetActive(false);
        }

        // Add notepad summary from notepad manager

        NotepadManager.Instance.SetSummaryNoteText(notesTXT.text);
        NotepadManager.Instance.AddNote();

        //close notepad UI
        notesTXT.text = "";
        CharacterSeletionGO.SetActive(false);
    }

    public void OnClickCancel() 
    {
        // delete notepad summary from notepad manager
        NotepadManager.Instance.ClearSelectedCharacter();
        notesTXT.text = "";

        //close notepad UI
        CharacterSeletionGO.SetActive(false);
    }

    IEnumerator ShowWarning() 
    {
        warningGO.SetActive(true);
        yield return new WaitForSeconds(warningDuration);
        warningGO.SetActive(false);
    }
}
