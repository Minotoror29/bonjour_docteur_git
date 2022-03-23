using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Son
    private AudioSource NextDay;
    private AudioSource Pas;
    private AudioClip NtoS;
    private AudioClip StoS;
    private AudioClip StoN;

    public float vol = 1;
    DialogueManager dialogueManager;
    public Village village;
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
        Pas = GameObject.Find("Patient Suivant").GetComponent<AudioSource>();
        NtoS = (AudioClip)Resources.Load("02_Sounds/0/EnterWithoutExit");
        StoS = (AudioClip)Resources.Load("02_Sounds/0/EnterWithExit");
        StoN = (AudioClip)Resources.Load("02_Sounds/0/NoEnterWithExit");

        dialogueManager = GetComponent<DialogueManager>();
        //village = GetComponent<Village>();
        salleDattente = GetComponent<SalleDattente>();

        jour = 1;

        D�butDeJourn�e();
    }

    void D�butDeJourn�e()
    {
        AudioListener.volume = vol;

        // Remplit la salle d'attente
        for (int i = 0; i < village.village.Count; i++)
        {
            salleDattente.salleDattente.Add(village.village[i]);
        }

        dialogueManager.PremierJour();
        Pas.clip = NtoS;
        Pas.Play();
        PatientSuivant();

    }

    // Remplit les informations du personnage sur la fiche de prescription � son arriv�e
    public void Informations()
    {
        prescription.transform.Find("Canvas").Find("Patient").GetComponent<Text>().text = "Patient : " + patient.nom.ToString();
        prescription.transform.Find("Canvas").Find("�ge").GetComponent<Text>().text = "�ge : " + patient.age.ToString();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Prescrire()
    {
        if (!patient.villageois)
            return;

        if (!patient.maladie)
            return;

        if (dialogueManager.dialogueIndex < 2)
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
        };

        if (salleDattente.salleDattente.Count == 0)
        {
            Pas.clip = StoN;
            Pas.Play();
        }
        else
        {
            Pas.clip = StoS;
            Pas.Play();
        };

        patient.GetComponent<Animator>().SetTrigger("Sortie");

        // Cr�e une fiche de prescription vierge
        Destroy(prescription);
        prescription = Instantiate(prescriptionPrefab, GameObject.Find("BUREAU").transform);
        prescription.transform.Find("Canvas").Find("Prescrire").GetComponent<Button>().onClick.AddListener(Prescrire);

        // Vide la bo�te de dialogues
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
            FinDeJourn�e();
            return;
        }

        patient.villageois = salleDattente.salleDattente[0];
        patient.AssignerPatient();
        patient.GetComponent<Animator>().SetTrigger("Entr�e");

        Informations();
    }

    public void D�butDialogue()
    {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue(patient);
    }

    void FinDeJourn�e()
    {
        AudioListener.volume = 0;
        crossFade.GetComponent<Animator>().SetTrigger("Fade");
    }

    public void Nuit()
    {
        if (jour == 1)
        {
            if (nuit == false)
            {
                SceneManager.LoadScene("Nuit", LoadSceneMode.Additive);
                nuit = true;
                StartCoroutine(TempsNuit());
            }
            else
            {
                SceneManager.UnloadSceneAsync("Nuit");
                nuit = false;
                JourSuivant();
            }
        } else
        {
            if (nuit == false)
            {
                Conclusion();
            }
        }
    }

    IEnumerator TempsNuit()
    {
        yield return new WaitForSeconds(2);
        crossFade.GetComponent<Animator>().SetTrigger("Fade");
    }

    public void JourSuivant()
    {
        if (patient.villageois)
            return;
        // Son
        NextDay.Play();

        jour = 2;

        D�butDeJourn�e();
        PatientSuivant();
    }

    void Conclusion()
    {
        AudioListener.volume = vol;
        SceneManager.LoadScene("Conclusion");
    }
}
