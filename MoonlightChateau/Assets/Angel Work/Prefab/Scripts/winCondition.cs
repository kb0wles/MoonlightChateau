using UnityEngine;
using UnityEngine.SceneManagement;

public class winCondition : MonoBehaviour
{
    [SerializeField] bool wonAllGames = false;
    [SerializeField] string trueEnding; // place holder
    [SerializeField] string falseEnding; // place holder

    int winCounter = 0;
    int allGamesWon = 3;

    public static winCondition Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Persist across scene loads
        }
    }

    public void ChooseEndings()
    {
        // Good ending
        if ( winCounter == allGamesWon)
        {
            TrueEnding();
        }
        // Bad ending
        else if ( winCounter != allGamesWon )
        {
            FalseEnding();
        }
    }

    public void WinCount()
    {
        winCounter++;
    }

    void TrueEnding()
    {
        // Go to the next scene
        SceneManager.LoadScene(trueEnding);
    }

    void FalseEnding()
    {
        // Go to the next scene
        SceneManager.LoadScene(falseEnding);

    }
}
