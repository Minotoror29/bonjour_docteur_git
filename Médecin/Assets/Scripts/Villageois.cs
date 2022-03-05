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

    public List<Conséquence> conséquences;

    public Villageois ChangeState(List<CONDITIONS> c)
    {
        if (conséquences.Count == 0)
        {
            return null;
        }

        if (c == null)
        {
            return null;
        }
        if (!c.Contains(CONDITIONS.Soigné))
        {
            return conséquences[0].conséquence;
        }

        foreach (Conséquence conséquence in conséquences)
        {
            if (conséquence.conditions == c)
            {
                return conséquence.conséquence;
            } else
            {
                return null;
            }
        }

        return null;
    }
}
