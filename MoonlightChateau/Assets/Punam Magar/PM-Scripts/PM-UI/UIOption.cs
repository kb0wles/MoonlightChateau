using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIOption : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    MenuSFXManager sfxManager;

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
    }

    public void UpdateSFXVol() 
    {
        sfxManager.settings.sfxVolume = sfxSlider.value;
        sfxManager.PlaySelect();
    }
}
