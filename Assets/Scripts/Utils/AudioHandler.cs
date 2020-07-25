using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    #region Audio Variables
    [Header("Audio Variables")]
    [SerializeField] private FloatReference musicVolume = null;
    [SerializeField] private FloatReference sfxVolume = null;
    [SerializeField] private AudioSource bgmAudioSource = null;
    [SerializeField] private AudioSource sfxAudioSource = null;
    #endregion

    private void Start()
    {
        bgmAudioSource.volume = musicVolume.Value;
        sfxAudioSource.volume = sfxVolume.Value;
    }

    public void MusicVolumeRefreshed()
    {
        bgmAudioSource.volume = musicVolume.Value;
    }

    public void SFXVolumeRefreshed()
    {
        sfxAudioSource.volume = sfxVolume.Value;
    }

    public void PlayAudio(Audio targetAudio)
    {
        AudioSource source = null;
        switch (targetAudio.type)
        {
            case AudioType.BGM:
                source = bgmAudioSource;
                break;
            case AudioType.SFX:
                source = sfxAudioSource;
                break;
            default:
            case AudioType.None:
                return;
        }

        source.clip = targetAudio.clip;
        source.loop = targetAudio.canLoop;
        source.Play();
    }
}
