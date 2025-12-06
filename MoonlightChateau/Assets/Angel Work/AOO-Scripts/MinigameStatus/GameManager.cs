using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Tracks wins and takes you to the choose ending scene
    public void Win()
    {
        // Updates wins
        if(winCondition.Instance != null)
        {
            winCondition.Instance.WinCount();
        }

        winCondition.Instance.ChooseEndings();
    }

    // Tracks loses and takes you to the corresponding ending
    public void Lose()
    {
        // Updates loses
        if (LoseManager.Instance != null)
        {
            LoseManager.Instance.UpdateCounter();
        }

        LoseManager.Instance.PlayEndings();
    }
}
