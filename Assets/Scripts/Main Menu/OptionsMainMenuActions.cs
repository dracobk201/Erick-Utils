using Basic_Variables;
using UnityEngine;
using UnityEngine.UI;

namespace Main_Menu
{
    public class OptionsMainMenuActions : MonoBehaviour
    {
        [Header("Data Variables")]
        public FloatReference musicVolume;
        public FloatReference soundVolume;

        [Header("Panel Variables")]
        public Slider soundSlider;
        public Slider musicSlider;

        public void Start()
        {
            soundSlider.onValueChanged.AddListener(delegate { SoundChanged(); });
            soundSlider.value = soundVolume.Value;
            musicSlider.onValueChanged.AddListener(delegate { MusicChanged(); });
            musicSlider.value = musicVolume.Value;
        }

        public void SoundChanged()
        {
            soundVolume.Value = soundSlider.value;
        }

        public void MusicChanged()
        {
            musicVolume.Value = musicSlider.value;
        }
    }
}
