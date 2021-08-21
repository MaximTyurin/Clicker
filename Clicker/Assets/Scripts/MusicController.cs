using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Text _musicText;

    private AudioSource _musicSource;
    private string _prefsKeyMusicVolume = "MusicVolume";

    private void Start()
    {
        _musicSource = GetComponentInChildren<AudioSource>();
        if (PlayerPrefs.HasKey(_prefsKeyMusicVolume) == false)
        {
            PlayerPrefs.SetInt(_prefsKeyMusicVolume, 3);
        }

        _musicSource.volume = (float)PlayerPrefs.GetInt(_prefsKeyMusicVolume) / 9;
        _musicSlider.value = PlayerPrefs.GetInt(_prefsKeyMusicVolume);
    }

    private void Update()
    {
        PlayerPrefs.SetInt(_prefsKeyMusicVolume, (int)_musicSlider.value);
        _musicSource.volume = (float)PlayerPrefs.GetInt(_prefsKeyMusicVolume) / 9;
        _musicText.text = _musicSlider.value.ToString();
    }
}
