using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    Text UIText;
    public string textToWrite;
    public int characterIndex;
    private AudioSource Voice;
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
        // Chercher l'audio source de la voix
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
                //Voice.PlayDelayed(Random.Range(0,1));

                if (characterIndex >= textToWrite.Length)
                {
                    UIText = null;
                    return;
                }
            }
        }
    }
}
