using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    #region Audio Variables
    [Header("Audio Variables")]
    [Tooltip("Volume for the Music")]
    [SerializeField] private FloatReference MusicVolume;
    [Tooltip("Volume for the SFX")]
    [SerializeField] private FloatReference SFXVolume;
    [Tooltip("Music Audio Source")]
    [SerializeField] AudioSource musicPlayer;
    [Tooltip("SFX Audio Source")]
    [SerializeField] AudioSource sfxPlayer;
    #endregion

    private void Start()
    {
        musicPlayer.volume = MusicVolume.Value;
        sfxPlayer.volume = SFXVolume.Value;
    }

    public void MusicVolumeRefreshed()
    {
        musicPlayer.volume = MusicVolume.Value;
    }

    public void SFXVolumeRefreshed()
    {
        sfxPlayer.volume = SFXVolume.Value;
    }
}
