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

    public List<Cons�quence> cons�quences;

    public Villageois ChangeState(List<CONDITIONS> c)
    {
        if (cons�quences.Count == 0)
        {
            return null;
        }

        if (c == null)
        {
            return null;
        }

        if (!c.Contains(CONDITIONS.Soign�))
        {
            return cons�quences[0].cons�quence;
        }

        foreach (Cons�quence cons�quence in cons�quences)
        {
            int i = 0;

            foreach (CONDITIONS c1 in cons�quence.conditions)
            {
                foreach (CONDITIONS c2 in c)
                {
                    if (c1 == c2)
                    {
                        i++;
                    }
                }
            }

            if (i == cons�quence.conditions.Count && i == c.Count)
            {
                return cons�quence.cons�quence;
            }
        }

        return null;
    }
}
