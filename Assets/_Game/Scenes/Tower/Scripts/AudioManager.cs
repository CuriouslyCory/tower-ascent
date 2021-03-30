using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public List<Sound> sounds;

    [SerializeField]
    private Slider volumeSlider;

    private bool isMuted;

    public static AudioManager instance;

    private void Awake() {
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = false;
        }
    }

    private void Start() {
        if(volumeSlider != null){
            volumeSlider.onValueChanged.AddListener(delegate {OnVolumeSliderChange();});
        }
        //Play("Theme");
        sounds[0].source.Play();
    }

    private void OnVolumeSliderChange()
    {
        foreach(Sound s in sounds){
            s.source.volume = volumeSlider.normalizedValue;
        }
    }

    public void OnMuteClick()
    {
        foreach(Sound s in sounds){
            if(isMuted){
                s.source.mute = false;
                isMuted = false;
            }else{
                s.source.mute = true;
                isMuted = true;
            }
        }
        
    }

    public void Play(string name)
    {
        Debug.Log("Playing " + name);
        Sound s = sounds.Find(sound => sound.name == name);
        if(s != null){
            s.source.Play();
        }else{
            Debug.LogWarning("Sound " + name + " not found");
        }
        
    }



}
