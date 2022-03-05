using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public void TriggerDialogue(Patient patient)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(patient);
    }
}
