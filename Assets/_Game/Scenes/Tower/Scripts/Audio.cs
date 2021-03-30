using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public AudioSource bgMusic;

    public AudioClip click;
    public AudioClip bleep;
    public AudioClip bloop;
    public AudioClip atk1;
    public AudioClip atk2;
    public AudioClip oof1;
    public AudioClip oof2;

    [SerializeField]
    private Slider volumeSlider;

    private bool isMuted;

    private void Start() {
        volumeSlider.onValueChanged.AddListener(delegate {OnVolumeSliderChange();});
    }

    private void OnVolumeSliderChange()
    {
        bgMusic.volume = volumeSlider.normalizedValue;
    }

    public void OnMuteClick()
    {
        if(isMuted){
            bgMusic.volume = 0.2f;
            isMuted = false;
        }else{
            bgMusic.volume = 0;
            isMuted = true;
        }
        
    }

}
