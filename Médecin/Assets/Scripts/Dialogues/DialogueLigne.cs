using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeLigne { Patient, Médecin }

public class DialogueLigne : MonoBehaviour
{
    public string ligne;
    public TypeLigne type;

    public float textSpeed;

    private void Start()
    {
        GetComponent<Text>().text = ligne;

        // Détermine qui parle et ajuste le texte en fonction
        if (type == TypeLigne.Patient)
        {
            GetComponent<Text>().alignment = TextAnchor.UpperLeft;
            GetComponent<Text>().color = new Color(0.5490196f, 0.8588236f, 0.8705883f);
        } else if (type == TypeLigne.Médecin)
        {
            GetComponent<Text>().alignment = TextAnchor.UpperRight;
            GetComponent<Text>().color = new Color(1f, 0.8274511f, 0.5803922f);
        }
    }
}
