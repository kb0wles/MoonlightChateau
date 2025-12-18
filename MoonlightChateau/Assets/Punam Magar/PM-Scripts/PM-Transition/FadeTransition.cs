using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class FadeTransition : MonoBehaviour
{
    public static FadeTransition Instance;
    [SerializeField] private Animator fadeAnimator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartFadeIn()
    {
        fadeAnimator.SetTrigger("FadeIN");
    }

    public void GoToNextScene() 
    {
        if (ManagerScene.Instance == null) 
        {
            return;
        }

        ManagerScene.Instance.PlayNextScene();
    }

    public void TriggerFadeIN()
    {
        if(SceneTracker.Instance.currentScene == ScenesStatus.SceneType.MINIGAME_4) 
        {
            // Do not trigger fade in on lobby scene
            return;
        }

        fadeAnimator.SetTrigger("FadeIN");
    }
}
