using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Patient : MonoBehaviour
{
    public VILLAGEOIS nom;
    public MALADIES maladie;
    public int age;

    public int �tat = 1;
    public int sous�tat = 1;

    //public Dialogue dialogue;

    public void DestroyPatient()
    {
        Destroy(gameObject);
    }

    // Fonctions qui vont d�terminer quels dialogues seront dit en fonction de l'�tat du personnage
    public abstract Phrase[] Introduction();
    public abstract Phrase[] Symptomes();
    public abstract Phrase[] Conclusion();

    public abstract void Prescription(List<TRAITEMENTS> traitements);
}
