using UnityEngine;

public class MenuSFXManager : MonoBehaviour
{
    public static MenuSFXManager Instance;

    public AudioSource sfxSource;
    public AudioSettingsSO settings;

    public AudioClip navigateSound;
    public AudioClip selectSound;

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        sfxSource = gameObject.AddComponent<AudioSource>();
        if (settings == null) settings = Resources.Load<AudioSettingsSO>("AudioSettings");
    }

    void Update()
    {
        if (settings != null) sfxSource.volume = settings.masterVolume * settings.sfxVolume;
    }

    public static MenuSFXManager Get()
    {
        if (Instance != null) return Instance;
        GameObject obj = new GameObject("MenuSFXManager");
        return obj.AddComponent<MenuSFXManager>();
    }

    public void PlayNavigate()
    {
        if (navigateSound == null) return;
        sfxSource.PlayOneShot(navigateSound);
    }

    public void PlaySelect()
    {
        if (selectSound == null) return;
        sfxSource.PlayOneShot(selectSound);
    }
}
