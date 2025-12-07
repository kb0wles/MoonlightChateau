using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Game Director that tells the entire game what to do next.
/// 
/// What it does:
/// - Gets win/loss reports from the minigames
/// - Gives the wins to winCondition script (Angel's), and losses to LoseManager script (Punam's)
/// - Lets the winCondition and LoseManager choose what scenes to load
/// </summary>
/// <remarks>
/// - Don't create extra GameManager instances on other scenes. This is a singleton class and uses DontDestroyOnLoad
/// - Minigame calls the GameManager.Instance.Win() when the player wins, and GameManager.Instance.Lose() when the player loses.
/// </remarks>

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
