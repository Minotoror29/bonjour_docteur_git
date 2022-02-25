using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    DialogueManager dialogueManager;
    Village village;
    SalleDattente salleDattente;

    GameObject patientObject;
    Patient patientScript;
    GameObject patientActuel;
    [SerializeField] GameObject prescriptionPrefab;
    [SerializeField] GameObject prescription;

    public GameObject dragDropPrefab;

    [SerializeField] GameObject dialogueViewportContent;

    private void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        village = GetComponent<Village>();
        salleDattente = GetComponent<SalleDattente>();

        DébutDeJournée();
    }

    void DébutDeJournée()
    {
        // Remplit la salle d'attente
        for (int i = 0; i < village.village.Count; i++)
        {
            salleDattente.salleDattente.Add(village.village[i]);
        }
    }

    // Remplit les informations du personnage sur la fiche de prescription à son arrivée
    void Informations()
    {
        prescription.transform.Find("Canvas").Find("Patient").GetComponent<Text>().text = "Patient : " + patientScript.nom.ToString();
        prescription.transform.Find("Canvas").Find("Âge").GetComponent<Text>().text = "Âge : " + patientScript.age.ToString();
    }

    public void Prescrire()
    {
        patientScript.Prescription(prescription.GetComponent<Prescription>().traitements);

        if (dialogueManager.dialogueIndex < 3)
            dialogueManager.ContinueDialogue(3);
    }

    public void FinConsultation()
    {
        patientActuel.GetComponent<Animator>().SetTrigger("Sortie");

        // Crée une fiche de prescription vierge
        Destroy(prescription);
        prescription = Instantiate(prescriptionPrefab, GameObject.Find("BUREAU").transform);
        prescription.transform.Find("Canvas").Find("Prescrire").GetComponent<Button>().onClick.AddListener(Prescrire);

        // Vide la boîte de dialogues
        for (int i = 0; i < dialogueViewportContent.transform.childCount; i++)
        {
            Destroy(dialogueViewportContent.transform.GetChild(i).gameObject);
        }

        salleDattente.salleDattente.Remove(patientObject);
        patientObject = null;
        patientScript = null;
        
    }

    public void PatientSuivant()
    {
        if (salleDattente.salleDattente.Count == 0)
            return;

        patientObject = salleDattente.salleDattente[0];
        patientScript = patientObject.GetComponent<Patient>();

        patientActuel = Instantiate(patientObject);

        Informations();

        FindObjectOfType<DialogueTrigger>().TriggerDialogue(patientScript);
    }

    public void JourSuivant()
    {
        DébutDeJournée();
    }
}
