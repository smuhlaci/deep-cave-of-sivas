using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{ 
    public Sound[] sounds;

    public static AudioManager instanceAudio;
    void Awake()
    {
        if (instanceAudio == null) instanceAudio = this;
        else 
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds) 
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = System.Array.Find(sounds, Sound => Sound.name == name);
        if (s == null) 
        {
            Debug.LogWarning("Sound:" + name + "not found!");
            return;
        }
        s.source.Play();
    }
}