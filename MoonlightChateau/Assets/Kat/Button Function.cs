using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    public void onStart()
    {

    }
   
    public void onChapter()
    {

    }

    public void onSettings()
    {

    }

    public void onCredits()
    {

    }

    public void onQuit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }



}
