using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Son
    private AudioSource Interruption;
    private AudioSource Continuer;
    private bool Star = false;
    
    GameManager gm;

    public Text texteDialogue;
    [SerializeField] RectTransform scrollViewContent;
    [SerializeField] GameObject ligneDialoguePrefab;

    Queue<string> phrases;
    Queue<TypeLigne> types;
    int ligneIndex = 0;
    public int dialogueIndex = 0;
    Phrase[] dialogueActuel;
    public Patient patient;

    public float textSpeed;

    public void PremierJour()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();

        phrases = new Queue<string>();
        types = new Queue<TypeLigne>();

        // Son
        Interruption = GameObject.Find("AudioInterruption").GetComponent<AudioSource>();
        Continuer = GameObject.Find("AudioContinuer").GetComponent<AudioSource>();
    }

    public void StartDialogue(Patient patient)
    {
        this.patient = patient;

        // Son
        Star = true;

        gm.Informations();
        ContinueDialogue(1);
    }

    public void ContinueDialogue(int dialogueIndex)
    {
        this.dialogueIndex = dialogueIndex;

        // Détermine à quelle partie du dialogue on est
        if (this.dialogueIndex == 1)
        {
            dialogueActuel = patient.Introduction();
        }
        else if (this.dialogueIndex == 2)
        {
            dialogueActuel = patient.Symptomes();
        }
        else if (this.dialogueIndex == 3)
        {
            dialogueActuel = patient.Conclusion();
        }


        phrases.Clear();
        types.Clear();

        foreach (Phrase phrase in dialogueActuel)
        {
            phrases.Enqueue(phrase.phrase);
            types.Enqueue(phrase.type);
        }

        ligneIndex = -1;
        PhraseSuivante();
    }

    public void PhraseSuivante()
    {
        // Son
        if (Star == false && patient.Pass == false)
        {
            Continuer.Play();
        }
        else
        {
            Star = false;
            patient.Pass = false;
        }

        if (!patient.villageois || !patient.pret)
        {
            return;
        }

        // Si le dialogue est fini on passe à la section suivante ou on finit la conversation
        if (phrases.Count == 0 && GetComponent<TextWriter>().characterIndex >= GetComponent<TextWriter>().textToWrite.Length)
        {
            if (dialogueIndex == 0)
            {
                return;
            }
            else if (dialogueIndex == 1)
            {
                ContinueDialogue(2);
                gm.patient.conditions.Add(CONDITIONS.PasInterrompu);
            }
            else if (dialogueIndex == 2)
            {
                if (!patient.maladie)
                {
                    ContinueDialogue(dialogueIndex + 1);
                } else
                {
                    return;
                }
            } 
            else if (dialogueIndex == 3)
            {
                FinDialogue();
                return;
            }
        }

        if (GetComponent<TextWriter>().characterIndex < GetComponent<TextWriter>().textToWrite.Length)
        {
            return;
        }

        // Affiche la réplique caractère par caractère
        string phrase = phrases.Dequeue();
        TypeLigne type = types.Dequeue();
        ligneIndex += 1;
        GameObject ligne = Instantiate(ligneDialoguePrefab, scrollViewContent);
        ligne.GetComponent<RectTransform>().position = new Vector2(ligne.GetComponent<RectTransform>().position.x, ligne.GetComponent<RectTransform>().position.y + 2);
        ligne.GetComponent<DialogueLigne>().type = type;
        if (type == TypeLigne.Médecin)
        {
            textSpeed = 0.01f;
        }
        else if (type == TypeLigne.Patient)
        {
            textSpeed = patient.villageois.textSpeed/* / 100f*/;
            //textSpeed = 0.05f;
        }
        GetComponent<TextWriter>().AddWriter(ligne.GetComponent<Text>(), phrase, textSpeed, true);
    }

    public void Interrompre()
    {
        if (dialogueIndex >= 2 || dialogueIndex == 0 || !patient.pret || !patient.villageois)
            return;

        ContinueDialogue(2);
        gm.patient.conditions.Add(CONDITIONS.Interrompu);
        // Son
        Interruption.Play();
    }

    void FinDialogue()
    {
        Debug.Log("Fin de la conversation");

        gm.FinConsultation();
    }
}
