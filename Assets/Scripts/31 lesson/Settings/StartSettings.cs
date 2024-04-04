using UnityEngine;

public class StartSettings 
{
    public StartSettings(BarButton barButton)
    {
        if (!PlayerPrefs.HasKey($"{GlobalStrings.START_VALUE_STRING}"))
        {
            PlayerPrefs.SetInt($"{GlobalStrings.SOUND_VOLUME_STRING}", 1);
            PlayerPrefs.SetInt($"{GlobalStrings.MUSIC_VOLUME_STRING}", 1);
            PlayerPrefs.SetInt($"{GlobalStrings.OPEN_LEVELS_STRING}", 1);
            PlayerPrefs.SetInt($"{GlobalStrings.BONUSES_STRING}", 0);

            PlayerPrefs.SetInt($"{GlobalStrings.START_VALUE_STRING}", 1);
        }
    }
}
