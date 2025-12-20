using TMPro;
using UnityEngine;

public class ButtonCharacterSelection : MonoBehaviour
{
    [SerializeField] CharacterProfile characterProfile;

    public CharacterProfile GetCharacterProfile()
    {
        return characterProfile;
    }
    public void UpdateSelectedCharacter()
    {
        NotepadManager.Instance.SetSelectedCharacter(characterProfile);
    }
}
