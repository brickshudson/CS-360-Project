using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer MenuMixer;

    public void setVolume(float sliderValue)
    {
        MenuMixer.SetFloat("MenuVolume", Mathf.Log10(sliderValue) *20);
    }

     void Awake()
    {
        
    }


}
