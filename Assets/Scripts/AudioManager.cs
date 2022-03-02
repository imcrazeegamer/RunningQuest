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
        if(instance != null)
        {
            instance.ToggleMusic(Settings.isMusic);
            instance.ToggleSFX(Settings.isSFX);
            Destroy(gameObject);
            return;
        }

        instance = this;
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.isLoop;
        }
        ToggleMusic(Settings.isMusic);
        ToggleSFX(Settings.isSFX);
        Play("music");
        DontDestroyOnLoad(gameObject);
    }
    
    
    public void Play(string name)
    {
        Sound s = Find(name);
        if(s.enabled == false)
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
        Find("music").enabled = value;
    }
    public void ToggleSFX(bool value)
    {
        foreach(Sound s in Array.FindAll(sounds, sound => sound.name != "music"))
        {
            s.enabled = value;
        }
    }
}
