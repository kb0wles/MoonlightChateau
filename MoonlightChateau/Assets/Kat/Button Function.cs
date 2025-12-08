using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    #region Title UI Buttons
    public void onQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void onStart()
    {
       UIManager.instance.stateGameStart();
    }
   
    public void onChapter()
    {
       UIManager.instance.stateChapter();
    }

    public void onOptions()
    {
        UIManager.instance.stateOptions();
    }

    public void onCredits()
    {
        UIManager.instance.stateCredits();
    }
    #endregion

    #region Menu UI Buttons
    public void onBack()
    {
        UIManager.instance.closeMenu();
    }
    public void onResume()
    {
        UIManager.instance.stateUnpause();
    }
    public void onMG1()
    {
        UIManager.instance.stateMinigame();
        SceneManager.LoadScene("Minigame 1 - E");
    }

    #endregion
}
