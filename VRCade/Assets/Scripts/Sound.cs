using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    //Name of the sound file
    public string name;

    public AudioClip clip;

    //volume of the file and the volume bar for inspector
    [Range(0f, 10f)]
    public float volume;

    //pitch of the sound and the pitch bar for inspector
    [Range(.1f, 5f)]
    public float pitch;

    //checkbox selection for inspector
    public bool loop;

    //Sets how much the 3D engine has an effect on the audio source.
    [Range(0f, 1f)]
    public float spatialBlend;

    //How fast the sound fades. The higher the value, the closer the Listener has to be before hearing the sound.
    //(This is determined by a Graph).
    public AudioRolloffMode rolloffMode;

    //Minimum distance you can hear the 3d sound from
    public float minDistance;

    //Maximum distance you can hear the 3d sound from
    public float maxDistance;

    [HideInInspector]
    public AudioSource source;
}
