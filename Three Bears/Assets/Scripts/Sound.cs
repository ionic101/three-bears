using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip Clip;

    [Range(0f, 1f)]
    public float Volume;

    [Range(0.1f, 3f)]
    public float Pitch;

    public bool Loop;

    private AudioSource source;

    [HideInInspector]
    public AudioSource Source
    {
        get
        {
            return source;
        }
        set
        {
            source = value;
            source.clip = Clip;
            source.volume = Volume;
            source.pitch = Pitch;
            source.loop = Loop;
        }
    }
}
