using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientObject : MonoBehaviour
{
    public Villageois villageois;

    public VILLAGEOIS nom;
    public MALADIES maladie;
    public int age;

    public Dialogue dialogue;

    public SpriteRenderer spriteRenderer;

    public void AssignerPatient()
    {
        nom = villageois.nom;
        maladie = villageois.maladie;
        age = villageois.age;
        dialogue = villageois.dialogue;

        spriteRenderer.sprite = villageois.sprite;
    }

    public Phrase[] Introduction()
    {
        return dialogue.introduction;
    }

    public Phrase[] Symptomes()
    {
        return dialogue.symptomes;
    }

    public Phrase[] Conclusion()
    {
        return dialogue.conclusion;
    }

    public void Prescription(List<TRAITEMENTS> traitements)
    {
        
    }
}
