using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    #region Title UI Buttons
    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void OnStart()
    {
       UIManager.instance.StateGameStart();
    }

    public void PlayMainGame() 
    {
        SceneManager.LoadScene("Beta_Intro");
    }
   
    public void OnChapter()
    {
       UIManager.instance.StateChapter();
    }

    public void OnOptions()
    {
        UIManager.instance.StateOptions();
    }

    public void OnCredits()
    {
        UIManager.instance.StateCredits();
    }
    #endregion

    #region Menu UI Buttons
    public void OnBack()
    {
        UIManager.instance.CloseMenu();
    }
    public void OnMenu()
    {
        UIManager.instance.StatePause();
    }
    public void OnNotes()
    {
        UIManager.instance.StateNotes();
    }
    public void OnResume()
    {
        UIManager.instance.StateUnpause();
    }
    public void OnMG1()
    {
        UIManager.instance.StateMinigame();
        SceneManager.LoadScene("Beta_MiniGame_1");
    }

    public void OnMG2()
    {
        UIManager.instance.StateMinigame();
        SceneManager.LoadScene("Beta_MiniGame_2");
    }

    public void OnMG3()
    {
        UIManager.instance.StateMinigame();
        SceneManager.LoadScene("Beta_MiniGame_3");
    }

    #endregion

    #region Notepad UI Buttons

    public void OnNotepadClose()
    {
        if(NotepadManager.Instance != null)
        {
            NotepadManager.Instance.OnClickCloseNotepad();
        }
    }

    public void OnNotepadOpen()
    {
        if (NotepadManager.Instance != null)
        {
            NotepadManager.Instance.OnClickOpenNotepad();
        }
    }

    #endregion
}
