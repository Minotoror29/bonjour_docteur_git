using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public void TriggerDialogue(PatientObject patient)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(patient);
    }
}
