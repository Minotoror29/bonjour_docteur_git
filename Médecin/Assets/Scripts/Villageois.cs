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
        List<CONDITIONS> conditions = new List<CONDITIONS>();

        for (int i = 0; i < c.Count; i++)
        {
            conditions.Add(c[i]);
        }

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

        for (int i = 0; i < cons�quences.Count; i++)
        {
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
