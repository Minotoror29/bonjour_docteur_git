using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    public Villageois villageois;

    public VILLAGEOIS nom;
    public Maladie maladie;
    public int age;

    public Dialogue dialogue;

    public SpriteRenderer spriteRenderer;

    bool prescription = false;

    public List<CONDITIONS> conditions;

    public void AssignerPatient()
    {
        nom = villageois.nom;
        if (maladie)
        {
            maladie = villageois.maladie;
        }
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
        if (prescription == true)
        {
            return dialogue.conclusion;
        } else
        {
            return dialogue.conclusion_2;
        }
    }

    public void Prescription(List<TRAITEMENTS> traitements)
    {
        if (traitements.Count == 0)
        {
            prescription = false;
        } else
        {
            prescription = true;
            conditions.Add(CONDITIONS.Soigné);
        }
    }

    public void ResetPatient()
    {
        villageois = null;
        nom = VILLAGEOIS.Personne;
        maladie = null;
        age = 0;

        dialogue = null;
        spriteRenderer.sprite = null;
    }
}
