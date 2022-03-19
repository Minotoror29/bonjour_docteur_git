using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radios : MonoBehaviour
{
    public bool Play = true;
    public AudioSource source;
    public AudioClip[] clips;

    void Start()
    {
        AudioSource source = GameObject.Find("Radio").GetComponent<AudioSource>();
    }

    void Awake()
    {
        clips = new AudioClip[] {
            (AudioClip)Resources.Load("02_Sounds/1/Radio01_01"),
            (AudioClip)Resources.Load("02_Sounds/1/Radio01_02"),
            (AudioClip)Resources.Load("02_Sounds/1/Radio01_03"),
            (AudioClip)Resources.Load("02_Sounds/1/Radio01_04"),
            (AudioClip)Resources.Load("02_Sounds/1/Radio01_05"),
            (AudioClip)Resources.Load("02_Sounds/1/Radio01_07"),
            (AudioClip)Resources.Load("02_Sounds/1/Radio02"),
            (AudioClip)Resources.Load("02_Sounds/1/Radio03"),
            (AudioClip)Resources.Load("02_Sounds/1/Radio04"),
        };
    }
    void Update()
    {
        if (!source.isPlaying && Play == true)
        {
            int randomClip = Random.Range(0, clips.Length);
            source.clip = clips[randomClip];
            source.Play();
        }
    }
}
