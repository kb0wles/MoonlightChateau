using UnityEngine.SceneManagement;
using UnityEngine;

public class LoseManager : MonoBehaviour
{
    public static LoseManager Instance;

    [Header("Max Lose")]
    [SerializeField] int maxLose;

    [Header("ScenesToLoad Name")]
    [SerializeField] string badEnding_Name;
    [SerializeField] string getAwayEnding_Name;
    
    int loseCount;

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

    public void UpdateCounter() 
    {
        loseCount++;
    }

    public void PlayEndings() 
    {
        if (loseCount == maxLose)
        {
            SceneManager.LoadScene(badEnding_Name);
        }
        else if (loseCount < maxLose) 
        {
            SceneManager.LoadScene(getAwayEnding_Name);
        }
    }
}
