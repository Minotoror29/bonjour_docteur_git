using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Villageois")]
public class Villageois : ScriptableObject
{
    public Sprite sprite;
    public VILLAGEOIS nom;
    public Maladie maladie;
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
            int i = 0;

            foreach (CONDITIONS c1 in conséquence.conditions)
            {
                foreach (CONDITIONS c2 in c)
                {
                    if (c1 == c2)
                    {
                        i++;
                    }
                }
            }

            if (i == conséquence.conditions.Count && i == c.Count)
            {
                return conséquence.conséquence;
            }
        }

        return null;
    }
}
