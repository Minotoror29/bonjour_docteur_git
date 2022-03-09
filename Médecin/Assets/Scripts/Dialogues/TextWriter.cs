using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    Text UIText;
    public string textToWrite;
    public int characterIndex;
    private GameObject voiceObj;
    private AudioSource voice;
    private float numberletters;
    float timePerCharacter;
    float timer;

    public void AddWriter(Text UIText, string textToWrite, float timePerCharacter)
    {
        this.UIText = UIText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        characterIndex = 0;
    }

    private void Start()
    {
        voiceObj = GameObject.Find("Voices");
        voice = voiceObj.GetComponent<AudioSource>();
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
                if (numberletters == 0)
                {
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
