using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Son : MonoBehaviour
{
    [SerializeField] Slider VolumeSlider;
    void Start()
    {
        VolumeSlider.value = AudioListener.volume;
    }

    public void VolumeChange()
    {
        AudioListener.volume = VolumeSlider.value;
    }
}
