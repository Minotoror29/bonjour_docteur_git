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

        maladie = villageois.maladie;
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

    public void Prescription(List<Traitement> traitements)
    {
        List<SYMPTOMES> symptomes = new List<SYMPTOMES>();

        for (int i = 0; i < maladie.symptomes.Count; i++)
        {
            symptomes.Add(maladie.symptomes[i]);
        }

        if (traitements.Count == 0)
        {
            prescription = false;
        } else
        {
            prescription = true;            
        }

        for (int i = 0; i < traitements.Count; i++)
        {
            for (int j = 0; j < traitements[i].symptomes.Count; j++)
            {
                for (int k = 0; k < maladie.symptomes.Count; k++)
                {
                    if (traitements[i].symptomes[j] == maladie.symptomes[k])
                    {
                        symptomes.Remove(maladie.symptomes[k]);
                    }
                }
            }
        }

        if (symptomes.Count == 0)
        {
            conditions.Add(CONDITIONS.Soigné);
        }
        else
        {
            conditions.Add(CONDITIONS.PasSoigné);
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
