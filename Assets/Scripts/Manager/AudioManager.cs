using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public Sounds [] sounds;

    void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return; 
        }

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;            
        }
    }

    private void Start() 
    {
        Play("Theme");
    }

    public void Stop(string name) 
    {
        Sounds s = Array.Find<Sounds>(sounds, sound => sound.name == name);
        if(s == null) return;
        s.source.Stop();
    }

    public void Play(string name) 
    {
        Sounds s = Array.Find<Sounds>(sounds, sound => sound.name == name);
        if(s == null) return;
        s.source.Play();
    }

    public float ClipLength(string name)
    {
        Sounds s = Array.Find<Sounds>(sounds, sound => sound.name == name);        
        float lenghth =  s.source.clip.length;
        return lenghth;
    }

}
