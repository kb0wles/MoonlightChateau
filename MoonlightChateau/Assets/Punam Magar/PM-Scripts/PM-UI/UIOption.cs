using UnityEngine;
using UnityEngine.UI;

public class UIOption : MonoBehaviour
{
    public MenuSFXManager sfxManager;

    [Header("Sliders")]
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    void Start()
    {
        sfxManager = MenuSFXManager.Get();
    }

    public void UpdateMusicVol()
    {
        sfxManager.settings.bgmVolume = musicSlider.value;
        sfxManager.PlayNavigate(); // can change to different sound if needed
        sfxManager.settings.mixer.SetFloat("music", (80 * sfxManager.settings.bgmVolume) - 80);
    }

    public void UpdateSFXVol()
    {
        sfxManager.settings.sfxVolume = sfxSlider.value;
        sfxManager.PlaySelect();
        sfxManager.settings.mixer.SetFloat("sfx", (80 * sfxManager.settings.sfxVolume) - 80);
    }
}
