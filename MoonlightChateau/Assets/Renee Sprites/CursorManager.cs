using UnityEngine;

public enum CursorType
{
    Default,
    Investigation,
    Dialogue,
    Minigame
}

public static class CursorManager
{
    private static Texture2D defaultCursor;
    private static Vector2 hotspot = Vector2.zero;

    public static void Init(Texture2D defaultTex)
    {
        defaultCursor = defaultTex;
        Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
    }

    public static void SetCursor(CursorType type)
    {
        Texture2D cursor = GetCursor(type);
        Cursor.SetCursor(cursor, hotspot, CursorMode.Auto);
    }

    public static void ResetCursor()
    {
        Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
    }

    private static Texture2D GetCursor(CursorType type)
    {
        return Resources.Load<Texture2D>($"Cursors/{type}");
    }
}