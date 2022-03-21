using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    //
    private AudioSource voice;
    public AudioClip[] voiceclips;
    private float numberletters;

    Text UIText;
    public string textToWrite;
    public int characterIndex;
    float timePerCharacter;
    float timer;

    public void AddWriter(Text UIText, string textToWrite, float timePerCharacter)
    {
        this.UIText = UIText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        characterIndex = 0;
    }

    private void Awake()
    {
        voiceclips = new AudioClip[] {
            (AudioClip)Resources.Load("02_Sounds/1/Voice01"),
            (AudioClip)Resources.Load("02_Sounds/1/Voice02"),
            (AudioClip)Resources.Load("02_Sounds/1/Voice03"),
        };
    }

    private void Start()
    {
        // Son
        voice = GameObject.Find("Voices").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (UIText != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer += timePerCharacter;
                characterIndex++;
                UIText.text = textToWrite.Substring(0, characterIndex);
                // Son
                if (numberletters == 0)
                {
                    int randomClip = Random.Range(0, voiceclips.Length);
                    voice.clip = voiceclips[randomClip];
                    voice.PlayDelayed(Random.Range(0, 3 / 2));
                }
                numberletters += 1;
                if (numberletters >= 5)
                {
                    numberletters = 0;
                }

                if (characterIndex >= textToWrite.Length)
                {
                    UIText = null;
                    return;
                }
            }
        }
    }
}
