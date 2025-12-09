using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    #region Fields
    public static UIManager instance;
    //UI containers
    //all containers will be active by default
    //menu ui active but submenus will not 
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject menuUI;
    //menus
    [SerializeField] GameObject menuActive;
    [SerializeField] GameObject menuChapter;
    [SerializeField] GameObject menuOptions;
    [SerializeField] GameObject menuCredits;
    [SerializeField] GameObject menuPause;
    [SerializeField] GameObject menuNotes;

    public bool isPaused;
    #endregion

    #region Lifecycle
    private void Awake()
    {
        instance = this;

        if (SceneManager.GetActiveScene().name == "UI Test Scene")
        {
            gameUI.SetActive(true);
            titleUI.SetActive(true);
            menuUI.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Minigame 1 - E" ||
            SceneManager.GetActiveScene().name == "Minigame 2 - E" ||
            SceneManager.GetActiveScene().name == "Minigame 3")
        {
            StateMinigame();
        }
    }
    void Start()
    {
        Time.timeScale = 1.0f;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Cancel"))
        {
            if (SceneManager.GetActiveScene().name != "UI Test Scene")
            {
                if (menuActive == null)
                {
                    StatePause();
                }
                else if (menuActive == menuPause)
                {
                    StateUnpause();
                }
            }
        }
    }
    #endregion

    #region Game States
    public void StateGameStart()
    {
        titleUI.SetActive(false);
    }
    public void StateMinigame()
    {
        gameUI.SetActive(false);
        titleUI.SetActive(false);
        menuUI.SetActive(true);
    }
    #endregion

    #region Menu States
    public void StatePause()
    { 
        isPaused = true;
        Time.timeScale = 0;
        menuActive = menuPause;
        menuActive.SetActive(true);
    }
    public void StateUnpause()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        menuActive.SetActive(false);
        menuActive = null;
    }
    public void StateChapter()
    {

        menuActive = menuChapter;
        menuActive.SetActive(true);
    }
    public void StateOptions()
    {
        menuActive = menuOptions;
        menuActive.SetActive(true);
    }
    public void StateCredits()
    {
        menuActive = menuCredits;
        menuActive.SetActive(true);
    }

    public void StateNotes()
    {
        menuActive = menuNotes;
        menuActive.SetActive(true);
    }
    public void CloseMenu()
    {
        menuActive.SetActive(false);
        menuActive = null;
        if (menuPause.activeSelf == true)
        {
            menuActive = menuPause;
        }
    }
    #endregion
}
