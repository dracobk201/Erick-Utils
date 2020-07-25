using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMainMenuActions : MonoBehaviour
{

    [Header("Data Variables")]
    [SerializeField] private FloatReference bgmVolume = null;
    [SerializeField] private FloatReference sfxVolume = null;
    [SerializeField] private BoolReference languageManuallyChanged = null;
    [SerializeField] private StringReference privacyPolicyLink = null;
    [SerializeField] private StringReference actualLanguage = null;
    [SerializeField] private GameEvent musicRefreshed = null;
    [SerializeField] private GameEvent soundRefreshed = null;
    [SerializeField] private GameEvent languageChanged = null;

    [Header("Panel Variables")]
    [SerializeField] private Slider musicSlider = null;
    [SerializeField] private Slider soundSlider = null;
    [SerializeField] private TMP_Dropdown languageDropdown = null;

    public void Start()
    {
        soundSlider.onValueChanged.AddListener(delegate { SoundChanged(); });
        soundSlider.value = sfxVolume.Value;
        musicSlider.onValueChanged.AddListener(delegate { MusicChanged(); });
        musicSlider.value = bgmVolume.Value;
        SetupDropdown();
    }

    private void SetupDropdown()
    {
        var languageNames = System.Enum.GetNames(typeof(Global.Language));
        languageDropdown.AddOptions(languageNames.ToList());
        languageDropdown.value = languageDropdown.options.FindIndex(x => x.text.Equals(actualLanguage.Value));
        languageDropdown.onValueChanged.AddListener(delegate
        {
            actualLanguage.Value = languageDropdown.options[languageDropdown.value].text;
            languageManuallyChanged.Value = true;
            languageChanged.Raise();
        });
    }

    public void SoundChanged()
    {
        sfxVolume.Value = soundSlider.value;
        soundRefreshed.Raise();
    }

    public void MusicChanged()
    {
        bgmVolume.Value = musicSlider.value;
        musicRefreshed.Raise();
    }

    public void OpenPrivacyPolicy()
    {
        Application.OpenURL(privacyPolicyLink.Value);
    }
}
