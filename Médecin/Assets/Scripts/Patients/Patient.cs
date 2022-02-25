using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Patient : MonoBehaviour
{
    public VILLAGEOIS nom;
    public MALADIES maladie;
    public int age;

    public int état = 1;
    public int sousÉtat = 1;

    //public Dialogue dialogue;

    public void DestroyPatient()
    {
        Destroy(gameObject);
    }

    // Fonctions qui vont déterminer quels dialogues seront dit en fonction de l'état du personnage
    public abstract Phrase[] Introduction();
    public abstract Phrase[] Symptomes();
    public abstract Phrase[] Conclusion();

    public abstract void Prescription(List<TRAITEMENTS> traitements);
}
