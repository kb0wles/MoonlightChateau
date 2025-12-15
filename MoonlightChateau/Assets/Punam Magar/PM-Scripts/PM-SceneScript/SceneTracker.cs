using UnityEngine;

public class SceneTracker : MonoBehaviour
{
    public static SceneTracker Instance;

    public ScenesStatus.SceneType currentScene;
    public ScenesStatus.SceneType nextSceneToLoad
        ;

    private void Awake()
    {
        //create a singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
