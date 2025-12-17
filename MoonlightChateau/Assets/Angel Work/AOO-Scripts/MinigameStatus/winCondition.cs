using UnityEngine;
using UnityEngine.SceneManagement;

public class winCondition : MonoBehaviour
{
    [SerializeField] bool wonAllGames = false;
    [SerializeField] string trueEnding; // place holder

    int winCounter = 0;
    [SerializeField] int allGamesWon = 3;

    public static winCondition Instance;

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

    public void ChooseEndings()
    {
        TrueEnding();
    }

    public void UpdateWinCounter() 
    {
        winCounter++;
    }

    public void WinCount()
    {
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

    public void PlayTrueEnding() 
    {
        if (winCounter >= allGamesWon) 
        {
            SceneManager.LoadScene(trueEnding);
        }
    }

    public void PickTrueEnding()
    {
        TrueEnding();
        Debug.Log("TRUE ENDING triggered");
    }
}
