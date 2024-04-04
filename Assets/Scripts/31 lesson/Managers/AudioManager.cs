using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private void Awake()
    {
        foreach ( Sound sound in sounds )
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
          
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.playOnAwake = sound.playOnAwake;
        }
        
        Initialize();

        DontDestroyOnLoad(gameObject);
    }

    public void Initialize()
    {
        //название звуков
        Sound coin = Array.Find(sounds, sound => sound.name == GlobalStrings.COIN_SOUND_STRING);
        Sound mainTheme = Array.Find(sounds, sound => sound.name == GlobalStrings.MAIN_THEME_STRING);

        // громкость
        coin.volume = PlayerPrefs.GetInt($"{GlobalStrings.SOUND_VOLUME_STRING}");
        mainTheme.volume = PlayerPrefs.GetInt($"{GlobalStrings.MUSIC_VOLUME_STRING}");
        
        if (mainTheme.volume != 0)
            PlaySound($"{GlobalStrings.MAIN_THEME_STRING}");
    }

    public void PlaySound(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void StopSound(string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    public bool IsPlayingSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return false;
        }
        return s.source.isPlaying;
    }

    public float LengthSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return 0;
        }
        return s.clip.length;
    }

    /// <summary>
    /// Change all sounds volume exept one sound
    /// </summary>
    /// <param name="value">value of volume</param>
    /// <param name="name">sound name which doesnt need to be changed </param>
    public void ChangeAllSoundsVolume(float value, string name)
    {
        foreach (var sound in sounds)
        {
            if (sound.name != name)
                sound.volume = value;

        }
    }

    public void ChangeAllSoundsVolume(float value)
    {
        foreach (var sound in sounds)
        {
            sound.volume = value;
        }
    }

    public void ChangeSoundVolume(string name, float value)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.volume = value;
    }

}
