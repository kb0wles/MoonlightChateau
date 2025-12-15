using UnityEngine;
using UnityEngine.SceneManagement;

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
        ManagerScene.Instance.PlayNextScene();
    }
}
