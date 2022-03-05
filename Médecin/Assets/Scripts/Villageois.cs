using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Villageois")]
public class Villageois : ScriptableObject
{
    public Sprite sprite;
    public VILLAGEOIS nom;
    public MALADIES maladie;
    public int age;

    public Dialogue dialogue;

    public void Condition()
    {
        Debug.Log("coucou");
    }
}
