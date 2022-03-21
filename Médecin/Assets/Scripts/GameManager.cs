using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Son
    private AudioSource NextPatient;
    private AudioSource NextDay;

    DialogueManager dialogueManager;
    Village village;
    SalleDattente salleDattente;

    public Patient patient;

    [SerializeField] GameObject prescriptionPrefab;
    [SerializeField] GameObject prescription;

    public GameObject dragDropPrefab;

    [SerializeField] GameObject dialogueViewportContent;

    [SerializeField] GameObject crossFade;
    int jour;
    bool nuit = false;

    private void Start()
    {
        // Son
        NextDay = GameObject.Find("Jour Suivant").GetComponent<AudioSource>();
        NextPatient = GameObject.Find("Patient Suivant").GetComponent<AudioSource>();

        dialogueManager = GetComponent<DialogueManager>();
        village = GetComponent<Village>();
        salleDattente = GetComponent<SalleDattente>();

        jour = 1;

        DébutDeJournée();
    }

    void DébutDeJournée()
    {
        // Remplit la salle d'attente
        for (int i = 0; i < village.village.Count; i++)
        {
            salleDattente.salleDattente.Add(village.village[i]);
        }

        dialogueManager.PremierJour();
        PatientSuivant();
    }

    // Remplit les informations du personnage sur la fiche de prescription à son arrivée
    void Informations()
    {
        prescription.transform.Find("Canvas").Find("Patient").GetComponent<Text>().text = "Patient : " + patient.nom.ToString();
        prescription.transform.Find("Canvas").Find("Âge").GetComponent<Text>().text = "Âge : " + patient.age.ToString();
    }

    public void Prescrire()
    {
        if (!patient.villageois)
            return;

        if (!patient.maladie)
            return;

        patient.Prescription(prescription.GetComponent<Prescription>().traitements);

        if (dialogueManager.dialogueIndex < 3)
            dialogueManager.ContinueDialogue(3);
    }

    public void FinConsultation()
    {
        if (patient.villageois.ChangeState(patient.conditions) != null)
        {
            for (int i = 0; i < village.village.Count; i++)
            {
                if (patient.villageois.nom == village.village[i].nom)
                {
                    village.village[i] = patient.villageois.ChangeState(patient.conditions);
                }
            }
        }

        patient.GetComponent<Animator>().SetTrigger("Sortie");

        // Crée une fiche de prescription vierge
        Destroy(prescription);
        prescription = Instantiate(prescriptionPrefab, GameObject.Find("BUREAU").transform);
        prescription.transform.Find("Canvas").Find("Prescrire").GetComponent<Button>().onClick.AddListener(Prescrire);

        // Vide la boîte de dialogues
        for (int i = 0; i < dialogueViewportContent.transform.childCount; i++)
        {
            Destroy(dialogueViewportContent.transform.GetChild(i).gameObject);
        }

        salleDattente.salleDattente.Remove(salleDattente.salleDattente[0]);
        patient.conditions.Clear();
    }

    public void PatientSuivant()
    {
        if (patient.villageois)
            return;

        if (salleDattente.salleDattente.Count == 0)
        {
            if (jour == 1)
            {
                FinDeJournée();
                return;
            } else if (jour == 2)
            {
                Conclusion();
                return;
            }
        }

        // Son
        NextPatient.Play();

        patient.villageois = salleDattente.salleDattente[0];
        patient.AssignerPatient();
        patient.GetComponent<Animator>().SetTrigger("Entrée");

        Informations();

        FindObjectOfType<DialogueTrigger>().TriggerDialogue(patient);
    }

    void FinDeJournée()
    {
        crossFade.GetComponent<Animator>().SetTrigger("Fade");
    }

    public void Nuit()
    {
        if (nuit == false)
        {
            SceneManager.LoadScene("Nuit", LoadSceneMode.Additive);
            nuit = true;
            StartCoroutine(TempsNuit());
        } else
        {
            SceneManager.UnloadSceneAsync("Nuit");
            nuit = false;
            JourSuivant();
        }
    }

    IEnumerator TempsNuit()
    {
        yield return new WaitForSeconds(3);
        crossFade.GetComponent<Animator>().SetTrigger("Fade");
    }

    public void JourSuivant()
    {
        if (patient.villageois)
            return;
        // Son
        NextDay.Play();

        jour = 2;

        DébutDeJournée();
        PatientSuivant();
    }

    void Conclusion()
    {

    }
}
