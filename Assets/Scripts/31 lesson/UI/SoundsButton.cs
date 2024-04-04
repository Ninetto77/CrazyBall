using UnityEngine;
using UnityEngine.UI;
using static BarButton;

public class SoundsButton : MonoBehaviour
{
    public enum TypeSettings
    {
        sound,
        music
    }
    public TypeSettings typeSetting;
    private Button _button;
    private AudioManager _audioManager;
    private BarButton _barButton;

    private string mainThemeString = GlobalStrings.MAIN_THEME_STRING;
    private string soundVolumeString = GlobalStrings.SOUND_VOLUME_STRING;
    private string musicVolumeString = GlobalStrings.MUSIC_VOLUME_STRING;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
        _barButton = transform.parent.GetComponent<BarButton>();
        _audioManager = FindAnyObjectByType<AudioManager>();

        Initialize();
    }

    void OnClick()
    {
        if (_audioManager != null )
        {
           if ( _barButton != null )
            {
                CheckTypeSetting();
            }
        }
    }

    private void Initialize()
    {
        switch (typeSetting)
        {
            case TypeSettings.sound:

                if (PlayerPrefs.GetInt(soundVolumeString) == 0)
                    _barButton.ChangeState(StateBar.off);
                else
                    _barButton.ChangeState(StateBar.on);
                break;
            case TypeSettings.music:
                if (PlayerPrefs.GetInt(musicVolumeString) == 0)
                    _barButton.ChangeState(StateBar.off);
                else
                    _barButton.ChangeState(StateBar.on);
                break;
        }
        
    }

    private void CheckTypeSetting()
    {
        if ( typeSetting == TypeSettings.sound )
        {
            ChangeSoundsValue();
        }
        else
        {
            ChangeMusicValue();
        }
    }

    private void ChangeMusicValue()
    {
        if (PlayerPrefs.GetInt(musicVolumeString) != 0)
        {
            PlayerPrefs.SetInt(musicVolumeString, 0);
            _audioManager.ChangeSoundVolume(mainThemeString, 0);
            _audioManager.StopSound(mainThemeString);
            _barButton.ChangeState(StateBar.off);

        }
        else
        {
            PlayerPrefs.SetInt(musicVolumeString, 1);
            _audioManager.ChangeSoundVolume(mainThemeString, 1);
            _audioManager.PlaySound(mainThemeString);
            _barButton.ChangeState(StateBar.on);
        }
    }


    private void ChangeSoundsValue()
    {
        if (PlayerPrefs.GetInt(soundVolumeString) != 0)
        {
            PlayerPrefs.SetInt(soundVolumeString, 0);
            _audioManager.ChangeAllSoundsVolume(0, mainThemeString);
            _barButton.ChangeState(StateBar.off);
        }
        else
        {
            PlayerPrefs.SetInt(soundVolumeString, 1);
            _audioManager.ChangeAllSoundsVolume(1, mainThemeString);
            _barButton.ChangeState(StateBar.on);
        }
    }
}

