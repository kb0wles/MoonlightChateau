using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public enum MinigameStatus
    {
        Win,
        Lose
    }

    public static GameManager Instance;

    public static event System.Action OnCanPlayEnding;
    public static event System.Action OnDialogueEnd;

    [SerializeField] GameObject changeScenesBTN;

    [SerializeField] int maxNumOfMinigames = 3;
    public int currentMinigameIndex = 0;

    [HideInInspector]
    public int dialogueEndCount = 0;

    [HideInInspector]
    public MinigameStatus prevMiniGameResult;

    int numOfCharsInScene;

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
            currentMinigameIndex++;
            prevMiniGameResult = MinigameStatus.Win;
        }

        FadeTransition.Instance.TriggerFadeIN();
        //CheckCanPlayEnding();

        //winCondition.Instance.ChooseEndings();
    }

    // Tracks loses and takes you to the corresponding ending
    public void Lose()
    {
        // Updates loses
        if (LoseManager.Instance != null)
        {
            LoseManager.Instance.UpdateCounter();
            currentMinigameIndex++;
            prevMiniGameResult = MinigameStatus.Lose;
        }

        FadeTransition.Instance.TriggerFadeIN();
        //CheckCanPlayEnding();

        //LoseManager.Instance.PlayEndings();
    }
    public void PlayEnding() 
    {
        if(LoseManager.Instance.loseCount != 0)
        {
            LoseManager.Instance.PlayEndings();
        }
        else 
        {
            winCondition.Instance.ChooseEndings();
        }

        FadeTransition.Instance.TriggerFadeIN();
    }

    public void CheckCanPlayEnding()
    {
        if(currentMinigameIndex >= maxNumOfMinigames) 
        {
            //OnCanPlayEnding?.Invoke();
            if(winCondition.Instance != null && LoseManager.Instance != null) 
            {
                PlayEnding();
                FadeTransition.Instance.TriggerFadeIN();
            }
        }
        else 
        {
            // Play Fide Transition and go to next scene
            FadeTransition.Instance.GoToNextScene();
        }
    }

    public void UpdateCharacterInScene(int numOfChars) 
    {
        numOfCharsInScene += numOfChars;
    }

    public void HasAllDialgueEnded() 
    {
        if(dialogueEndCount >= numOfCharsInScene) 
        {
            OnDialogueEnd?.Invoke();
            //ManagerScene.Instance.PlayNextScene();
            // Play Fide Transition and go to next scene
            FadeTransition.Instance.GoToNextScene();
        }
    }

    public bool IsAllDialogueEnded() 
    {
        return dialogueEndCount >= numOfCharsInScene;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += ResetDialogueVariables;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ResetDialogueVariables;
    }

    public void ResetDialogueVariables(Scene scene, LoadSceneMode mode) 
    {
        dialogueEndCount = 0;
        numOfCharsInScene = 0;
    }
}
