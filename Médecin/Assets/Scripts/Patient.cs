using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    // Son
    private AudioSource Prescript;
    public bool Pass = false;
    private bool Make = false;
    private AudioSource Sound;
    private AudioClip[] Clips;
    private float Timer = 10;

    public Villageois villageois;

    public VILLAGEOIS nom;
    public Maladie maladie;
    public int age;

    public Dialogue dialogue;

    public SpriteRenderer spriteRenderer;

    bool prescription = false;

    public List<CONDITIONS> conditions;

    public bool pret = false;

    private void Start()
    {
        // Son
        Prescript = GameObject.Find("AudioPrescript").GetComponent<AudioSource>();
        Sound = gameObject.GetComponent<AudioSource>();
    }

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

        Clips = villageois.clip;
    }

    public void LancerDialogue()
    {
        pret = true;
        FindObjectOfType<GameManager>().DébutDialogue();
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
        // Son
        if (Make == false)
        {
            Prescript.Play();
            Pass = true;
            Make = true;
        }

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
        // Son
        Make = false;

        villageois = null;
        nom = VILLAGEOIS.Personne;
        maladie = null;
        age = 0;

        dialogue = null;
        spriteRenderer.sprite = null;

        pret = false;
    }

    public void PatientSuivant()
    {
        FindObjectOfType<GameManager>().PatientSuivant();
    }

    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0 && Clips.Length !=0)
        {
            int randomClip = Random.Range(0, Clips.Length);
            Sound.clip = Clips[randomClip];
            Sound.pitch = UnityEngine.Random.Range(0.95f, 1.05f);
            Sound.Play();
            Timer = UnityEngine.Random.Range(10f,30f);
        }
    }

    public void Sortie()
    {
        pret = false;
    }
}
