using UnityEditor;

[CustomEditor(typeof(DialogueNode))]
public class DialogueNodeEditor : Editor
{
    SerializedProperty hasNotepadSummary;
    SerializedProperty notepadSummary;

    private void OnEnable()
    {
        hasNotepadSummary = serializedObject.FindProperty("hasNotepadSummary");
        notepadSummary = serializedObject.FindProperty("notepadSummary");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawPropertiesExcluding(serializedObject, "notepadSummary", "m_Script");

        if (hasNotepadSummary.boolValue)
        {
            EditorGUILayout.PropertyField(notepadSummary);
        }

        serializedObject.ApplyModifiedProperties();
    }
}