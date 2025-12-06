using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNode", menuName = "Dialogue/Node")]
public class DialogueNode : ScriptableObject
{
    [TextArea (5,8)]
    public string dialogueText;
    public CharacterProfile character;
    public EmotionType emotion;

    [System.Serializable]
    public struct Choice
    {
        public string choiceLabel;
        public DialogueNode nextNode;
    }

    public List<Choice> choices;
}
