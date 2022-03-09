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
        List<CONDITIONS> conditions = new List<CONDITIONS>();

        for (int i = 0; i < c.Count; i++)
        {
            conditions.Add(c[i]);
        }

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

        for (int i = 0; i < conséquences.Count; i++)
        {
            for (int j = 0; j < conséquences[i].conditions.Count; j++)
            {
                for (int k = 0; k < c.Count; k++)
                {
                    if (conséquences[i].conditions[j] == c[k])
                    {
                        conditions.Remove(c[k]);
                    }
                }
            }

            if (conditions.Count == 0)
            {
                return conséquences[i].conséquence;
            }
        }

        return null;
    }
}
