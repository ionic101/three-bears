using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private static bool isPlay = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        foreach (var sound in sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Start()
    {
        if (!isPlay)
        {
            Play("bg");
            isPlay = true;
        }
            
    }

    public void Play(string name)
    {
        var sound = Array.Find(sounds, sound => sound.Name == name);
        if (sound == null)
            throw new Exception("Cant find sound");
        sound.Source.Play();
    }
}
