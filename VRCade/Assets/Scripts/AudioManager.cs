using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AudioManager : MonoBehaviour
{
    //list of sounds that are selected to be played
    public Sound[] sounds;
    public Slider volumeSlider;
    //instance of the AudioManager object. There should not be more than one audiomanager in the game 
    //even when the scenes change
    public static AudioManager instance;

    // Use this for initialization
    void Awake()
    {
        //if there is no AudioManager object, assign this as the audiomanager
        //else, destroy the object and return. 
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Method to avoid the destruction of audioManager when scenes change
        DontDestroyOnLoad(gameObject);

        //for each sound that are listed, different options should be available. 
        foreach (Sound s in sounds)
        {

            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
            s.source.rolloffMode = s.rolloffMode;
            s.source.minDistance = s.minDistance;
            s.source.maxDistance = s.maxDistance;
        }
    }

    //default sound track when the game starts
    void Start()
    {
        Debug.LogWarning("Here");
        //Play("theme");
    }
    void Update()
    {
        //changeMasterVolume("theme");
    }
    //Method called to play the sound based on the fileName provided
    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + soundName + "not found");
            return;
        }
        s.source.Play();
    }
    void changeMasterVolume(string soundName)
    {
        Sound mvs = Array.Find(sounds, sound => sound.name == soundName);
        mvs.source.volume = volumeSlider.value;
    }
}

