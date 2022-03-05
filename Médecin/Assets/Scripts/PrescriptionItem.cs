using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PrescriptionItem : MonoBehaviour, IDropHandler
{
    public TRAITEMENTS traitement;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            // Remplit l'information en drag & droppant un item dans un slot
            GetComponent<Text>().text = eventData.pointerDrag.GetComponent<Text>().text;
            traitement = eventData.pointerDrag.GetComponent<Traitement>().traitement;

            // Rajoute des slots au fur et à mesure que l'on remplit la presciption
            if (transform.GetSiblingIndex() < transform.parent.childCount - 1)
                transform.parent.GetChild(transform.GetSiblingIndex() + 1).gameObject.SetActive(true);

            FindObjectOfType<Prescription>().traitements.Add(traitement);
        }
    }
}
