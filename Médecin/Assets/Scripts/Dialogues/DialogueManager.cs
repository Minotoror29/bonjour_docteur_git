using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
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

    private void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();

        phrases = new Queue<string>();
        types = new Queue<TypeLigne>();
    }

    public void StartDialogue(Patient patient)
    {
        this.patient = patient;

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
        if (!patient.villageois)
        {
            return;
        }

        // Si le dialogue est fini on passe à la section suivante ou on finit la conversation
        if (phrases.Count == 0)
        {
            if (dialogueIndex == 1)
            {
                ContinueDialogue(dialogueIndex + 1);
                gm.patient.conditions.Add(CONDITIONS.PasInterrompu);
            }
            else if (dialogueIndex == 2)
            {
                return;
            } else if (dialogueIndex == 3)
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
        GetComponent<TextWriter>().AddWriter(ligne.GetComponent<Text>(), phrase, 0.01f);
        ligne.GetComponent<DialogueLigne>().type = type;        
    }

    public void Interrompre()
    {
        if (dialogueIndex >= 2 || dialogueIndex == 0)
            return;

        ContinueDialogue(2);
        gm.patient.conditions.Add(CONDITIONS.Interrompu);
    }

    void FinDialogue()
    {
        Debug.Log("Fin de la conversation");

        gm.FinConsultation();
    }
}
