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
        if (!wonAllGames)
            return;

        SceneManager.LoadScene("EndingChoiceScene"); // Replace with the actual scene name
    }

    public void WinCount()
    {
        winCounter++;

        if (winCounter >= allGamesWon)
        {
            wonAllGames = true;
        }
    }

    void TrueEnding()
    {
        // Go to the next scene
        if (wonAllGames)
        {
            SceneManager.LoadScene(trueEnding);
        }
    }

    void FalseEnding()
    {
        // Go to the next scene
        if (wonAllGames)
        {
            SceneManager.LoadScene(falseEnding);
        }

    }

    public void PickTrueEnding()
    {
        TrueEnding();
        Debug.Log("TRUE ENDING triggered");
    }

    public void PickFalseEnding()
    {
        FalseEnding();
        Debug.Log("FALSE ENDING triggered");
    }
}
