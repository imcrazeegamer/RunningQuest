using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    void Awake()
    {
        if (instance != null)
        {
            instance.ToggleMusic(Settings.isMusic);
            instance.ToggleSFX(Settings.isSFX);
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume * Settings.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.isLoop;
            s.source.playOnAwake = false;
        }
        ToggleMusic(Settings.isMusic);
        ToggleSFX(Settings.isSFX);
        
        DontDestroyOnLoad(gameObject);
    }


    public void Play(string name, bool play = true)
    {
        if (!play)
        {
            Stop(name);
            return;
        }
        Sound s = Find(name);
        if(s == null || s.enabled == false)
        {
            return;
        }
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Find(name);
        if (s.enabled == false)
        {
            return;
        }

        s.source.Stop();
    }
    public void StopAll()
    {
        foreach (Sound s in sounds)
            s.source.Stop();
    }
    public void Pause(string name)
    {
        Sound s = Find(name);
        if (s.enabled == false)
        {
            return;
        }
        s.source.Pause();
    }
    public void Resume(string name)
    {
        Sound s = Find(name);
        if (s.enabled == false)
        {
            return;
        }
        s.source.UnPause();
    }
    public void Enable(string name)
    {
        Sound s = Find(name);
        
        s.enabled = true;
    }
    public void Disable(string name)
    {
        Sound s = Find(name);
        s.enabled = false;
    }
    Sound Find(string name)
    {
        return Array.Find(sounds, sound => sound.name == name);
    }
    public void ToggleMusic(bool value)
    {
        Find("musicBattle").enabled = value;
        Find("musicShop").enabled = value;
        Find("musicMainMenu").enabled = value;
    }
    public void ToggleSFX(bool value)
    {
        foreach(Sound s in Array.FindAll(sounds, sound => sound.name != "musicBattle" && sound.name != "musicShop" && sound.name != "musicMainMenu"))
        {
            s.enabled = value;
        }
    }

    public void UpdateMasterVolume()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = s.volume * Settings.volume;
        }
    }
}
