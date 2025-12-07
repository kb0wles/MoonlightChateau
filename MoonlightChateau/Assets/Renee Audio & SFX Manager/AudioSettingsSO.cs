using UnityEngine;

[CreateAssetMenu(fileName = "AudioSettingsSO", menuName = "Audio/Audio Settings")]
public class AudioSettingsSO : ScriptableObject
{
    public float masterVolume = 1f;
    public float bgmVolume = 1f;
    public float sfxVolume = 1f;

    public AudioClip defaultBGM;
    internal float musicVolume;
}