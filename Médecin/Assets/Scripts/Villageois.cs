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

    public int textSpeed;

    public Dialogue dialogue;

    public List<Cons�quence> cons�quences;

    public Villageois ChangeState(List<CONDITIONS> c)
    {
        List<CONDITIONS> conditions = new List<CONDITIONS>();

        if (cons�quences.Count == 0)
        {
            return null;
        }

        if (c == null)
        {
            return null;
        }

        for (int i = 0; i < cons�quences.Count; i++)
        {
            conditions.Clear();
            for (int l = 0; l < cons�quences[i].conditions.Count; l++)
            {
                conditions.Add(cons�quences[i].conditions[l]);
            }

            for (int j = 0; j < cons�quences[i].conditions.Count; j++)
            {
                for (int k = 0; k < c.Count; k++)
                {
                    if (cons�quences[i].conditions[j] == c[k])
                    {
                        conditions.Remove(c[k]);
                    }
                }
            }

            if (conditions.Count == 0)
            {
                return cons�quences[i].cons�quence;
            }
        }

        return null;
    }
}
