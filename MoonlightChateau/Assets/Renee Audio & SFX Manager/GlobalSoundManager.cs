using UnityEngine;

public class GlobalAudioManager : MonoBehaviour
{
    public static GlobalAudioManager Instance;

    AudioSource sfxSource;
    AudioSettingsSO settings;

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        sfxSource = gameObject.AddComponent<AudioSource>();
        settings = Resources.Load<AudioSettingsSO>("AudioSettings");
    }

    void Update()
    {
        if (settings != null) sfxSource.volume = settings.sfxVolume;
    }

    public static GlobalAudioManager Get()
    {
        if (Instance != null) return Instance;
        GameObject obj = new GameObject("GlobalAudioManager");
        return obj.AddComponent<GlobalAudioManager>();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip);
    }

    public void StopAllSFX()
    {
        sfxSource.Stop();
    }
}