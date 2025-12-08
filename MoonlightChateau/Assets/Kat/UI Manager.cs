using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
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
    float timeScaleOrig;

    private void Awake()
    {
        instance = this;
        timeScaleOrig = Time.timeScale;

        if (SceneManager.GetActiveScene().name == "UI Test Scene")
        {
            gameUI.SetActive(true);
            titleUI.SetActive(true);
            menuUI.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Minigame 1 - E" ||
            SceneManager.GetActiveScene().name == "Minigame 2 - E" ||
            SceneManager.GetActiveScene().name == "Minigame 1 - E")
        {
            stateMinigame();
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
            if (menuActive == null)
            {
                statePause();
                menuActive = menuPause;
                menuActive.SetActive(true);
            }
            else if (menuActive == menuPause)
            {
                stateUnpause();
            }
        }
    }
    public void statePause()
    {
        isPaused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;

    }
    public void stateUnpause()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        menuActive.SetActive(false);
        menuActive = null;
    }
    public void stateGameStart()
    {
        titleUI.SetActive(false);
    }
    public void stateChapter()
    {

        menuActive = menuChapter;
        menuActive.SetActive(true);
    }
    public void stateOptions()
    {

        menuActive = menuOptions;
        menuActive.SetActive(true);
    }
    public void stateCredits()
    {
        menuActive = menuCredits;
        menuActive.SetActive(true);
    }
    public void stateMinigame()
    {
        gameUI.SetActive(false);
        titleUI.SetActive(false);
        menuUI.SetActive(true);
    }

    public void closeMenu()
    {
            menuActive.SetActive(false);
            menuActive = null;
    }
}
