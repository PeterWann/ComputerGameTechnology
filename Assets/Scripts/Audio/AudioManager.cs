using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager Instance { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.spatialBlend = s.spatialBlend;
        }
    }

    public void Play(string name)
    {
        Sound currentSound = Array.Find(sounds, sound => sound.name == name);

        if (currentSound != null && !currentSound.source.isPlaying)
        {
            currentSound.source.Play();
        }
    }

    public void PlayOnce(string name)
    {
        Sound currentSound = Array.Find(sounds, sound => sound.name == name);

        if (currentSound != null)
        {
            currentSound.source.Play();
        }
    }

    public void PlayLoop(string name)
    {
        Sound currentSound = Array.Find(sounds, sound => sound.name == name);

        if (currentSound != null)
        {
            currentSound.source.loop = true;
            currentSound.source.Play();
        }
    }

    public void StopPlay(string name)
    {
        Sound currentSound = Array.Find(sounds, sound => sound.name == name);

        if (currentSound != null)
        {
            currentSound.source.Stop();
        }
    }
}
