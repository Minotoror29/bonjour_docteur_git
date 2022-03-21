using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lettre : MonoBehaviour
{
    public GameObject Letter;
    public AudioSource Ambiance;
    private AudioClip Base;
    private AudioClip After;
    private bool yes = false;

    void Start()
    {
        Base = (AudioClip)Resources.Load("02_Sounds/0/AmbianceCabinetMatin");
        After = (AudioClip)Resources.Load("02_Sounds/0/AmbianceCabinetJournéeLoop");
        Ambiance.clip = Base;
        Ambiance.Play();
    }

    void Update()
    {
        if (!Ambiance.isPlaying && yes == false)
        {
            yes = true;
            Ambiance.clip = After;
            Ambiance.Play();
            Ambiance.loop = true;
        }
    }
}
