using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public static ManagerScene Instance;

    [Header("Scene's Name")]
    [SerializeField] string ACT_1;
    [SerializeField] string ACT_2;
    [SerializeField] string ACT_3;
    [SerializeField] string MINIGAME_1;
    [SerializeField] string MINIGAME_2;
    [SerializeField] string MINIGAME_3;
    [SerializeField] string MINIGAME_4;
    [SerializeField] string MG3_GARDEN;
    [SerializeField] string LOBBY;
    [SerializeField] string FOX_FE;
    [SerializeField] string BEAR_FE;
    [SerializeField] string RABBIT_GE;
    [SerializeField] string CREDITS;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlayNextScene() 
    {
        if(SceneTracker.Instance == null) 
        {
            Debug.LogWarning("SceneTracker Instance is null!");
            return;
        }

        if(SceneTracker.Instance.currentScene == ScenesStatus.SceneType.LOBBY) 
        {
            GameManager.Instance.PlayEnding();
            return;
        }

        LoadScene(SceneTracker.Instance.nextSceneToLoad);
    }

    public void PlayGardenScene() 
    {
        SceneManager.LoadScene(MG3_GARDEN);
    }

    public void PlayLobbyScene() 
    {
        SceneManager.LoadScene(LOBBY);
    }

    void LoadScene(ScenesStatus.SceneType sceneType) 
    {
        switch (sceneType)
        {
            case ScenesStatus.SceneType.ACT_1:
                SceneManager.LoadScene(ACT_1);
                break;
            case ScenesStatus.SceneType.ACT_2:
                SceneManager.LoadScene(ACT_2);
                break;
            case ScenesStatus.SceneType.ACT_3:
                SceneManager.LoadScene(ACT_3);
                break;
            case ScenesStatus.SceneType.MINIGAME_1:
                SceneManager.LoadScene(MINIGAME_1);
                break;
            case ScenesStatus.SceneType.MINIGAME_2:
                SceneManager.LoadScene(MINIGAME_2);
                break;
            case ScenesStatus.SceneType.MINIGAME_3:
                SceneManager.LoadScene(MINIGAME_3);
                break;
            case ScenesStatus.SceneType.MINIGAME_4:
                SceneManager.LoadScene(MINIGAME_4);
                break;
            case ScenesStatus.SceneType.MG3_GARDEN:
                SceneManager.LoadScene(MG3_GARDEN);
                break;
            case ScenesStatus.SceneType.LOBBY:
                SceneManager.LoadScene(LOBBY);
                break;
            case ScenesStatus.SceneType.CREDITS:
                SceneManager.LoadScene(CREDITS);
                break;
        }
    }

    public void PlaySpecificScene(ScenesStatus.SceneType sceneType) 
    {
        LoadScene(sceneType);
    }

    public void PlayFoxFE() 
    {
        SceneManager.LoadScene(FOX_FE);
    }

    public void PlayBearFE() 
    {
        SceneManager.LoadScene(BEAR_FE);
    }

    public void PlayRabbitGE() 
    {
        SceneManager.LoadScene(RABBIT_GE);
    }
}
