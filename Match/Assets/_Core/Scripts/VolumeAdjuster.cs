using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeAdjuster : MonoBehaviour {

    public Slider volumeSlider;
    public AudioSource volumeAudio;


    public void OnValueChanged()
    {
        volumeAudio.volume = volumeSlider.value;
    }

}
