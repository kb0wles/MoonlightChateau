using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    AudioSource musicSource;
    public AudioSettingsSO settings;

    public AudioClip menuLoop;
    public AudioClip gardenLoop;
    public AudioClip barLoop;
    public AudioClip lobbyLoop;
    public AudioClip loungeLoop;
    public AudioClip miniGame1Loop;
    public AudioClip miniGame2Loop;

    public AudioClip pickKillerLoop;
    public AudioClip escapeLoop;
    public AudioClip dieLoop;
    public AudioClip falseAccuseLoop;
    public AudioClip catchKillerLoop;

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        if (settings == null) settings = Resources.Load<AudioSettingsSO>("AudioSettings");
    }

    void Update()
    {
        if (settings != null) musicSource.volume = settings.masterVolume * settings.bgmVolume;
    }

    public static MusicManager Get()
    {
        if (Instance != null) return Instance;
        GameObject obj = new GameObject("MusicManager");
        return obj.AddComponent<MusicManager>();
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        if (musicSource.clip == clip && musicSource.isPlaying) return;
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
