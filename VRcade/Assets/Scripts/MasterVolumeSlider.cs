using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolumeSlider : MonoBehaviour {

    public Slider volumeSlider;
    public AudioSource masterVolume;
	// Update is called once per frame
	void Update () {
        masterVolume.volume = volumeSlider.value;
	}
}
