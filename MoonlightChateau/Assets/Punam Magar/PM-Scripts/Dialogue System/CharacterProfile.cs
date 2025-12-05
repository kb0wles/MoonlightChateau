using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Dialogue/Character")]
public class CharacterProfile : ScriptableObject
{
    public string characterName;

    [System.Serializable]
    public struct Portrait
    {
        public Sprite image;
        public EmotionType emotion;
    }

    public List<Portrait> portraits;

    public Sprite GetPortraitByEmotion(EmotionType emotionType)
    {
        foreach (Portrait portrait in portraits)
        {
            if (portrait.emotion == emotionType)
            {
                return portrait.image;
            }
        }
        return null;
    }
}
