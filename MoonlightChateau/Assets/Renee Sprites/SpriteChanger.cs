using System.Collections.Generic;
using UnityEngine;

public enum Emotion
{
    Happy,
    Sad,
    Angry
}

public static class EmotionSpriteDB
{
    private static Dictionary<Emotion, Dictionary<string, Sprite>> db;

    public static Sprite Get(string character, Emotion emotion)
    {
        if (db == null)
            Load();

        if (!db.ContainsKey(emotion))
        {
            Debug.LogWarning("Emotion not found: " + emotion);
            return null;
        }

        if (!db[emotion].ContainsKey(character))
        {
            Debug.LogWarning("Sprite missing for " + character + " (" + emotion + ")");
            return null;
        }

        return db[emotion][character];
    }

    private static void Load()
    {
        db = new Dictionary<Emotion, Dictionary<string, Sprite>>();

        LoadEmotion(Emotion.Happy, "EmotionSprites/Happy");
        LoadEmotion(Emotion.Sad, "EmotionSprites/Sad");
        LoadEmotion(Emotion.Angry, "EmotionSprites/Angry");
    }

    private static void LoadEmotion(Emotion emotion, string path)
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(path);

        Dictionary<string, Sprite> map = new Dictionary<string, Sprite>();

        foreach (Sprite s in sprites)
            map[s.name] = s;

        db[emotion] = map;
    }
}


// to use example: portrait.sprite = EmotionSpriteDB.Get("Rabbit", Emotion.Happy);