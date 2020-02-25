using Basic_Variables;
using UnityEngine;

namespace Utils
{
    public class AudioHandler : MonoBehaviour
    {
        #region Audio Variables
        [Header("Audio Variables")]
        [Tooltip("Volume for the Music")]
        [SerializeField] private FloatReference musicVolume;
        [Tooltip("Volume for the SFX")]
        [SerializeField] private FloatReference sfxVolume;
        [Tooltip("Music Audio Source")]
        [SerializeField] AudioSource musicPlayer;
        [Tooltip("SFX Audio Source")]
        [SerializeField] AudioSource sfxPlayer;
        #endregion

        private void Start()
        {
            musicPlayer.volume = musicVolume.Value;
            sfxPlayer.volume = sfxVolume.Value;
        }

        public void MusicVolumeRefreshed()
        {
            musicPlayer.volume = musicVolume.Value;
        }

        public void SfxVolumeRefreshed()
        {
            sfxPlayer.volume = sfxVolume.Value;
        }
    }
}
