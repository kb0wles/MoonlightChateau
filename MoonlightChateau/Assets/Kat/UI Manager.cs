using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    //menus
    [SerializeField] GameObject menuActive;
    [SerializeField] GameObject menuChapter;
    [SerializeField] GameObject menuSettings;
    [SerializeField] GameObject menuCredits;
    [SerializeField] GameObject menuPause;
    [SerializeField] GameObject menuNotes;
    //UI containers
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject menuUI;

    public bool isPaused;
    float timeScaleOrig;

    private void Awake()
    {
        instance = this;
        timeScaleOrig = Time.timeScale;
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
}
