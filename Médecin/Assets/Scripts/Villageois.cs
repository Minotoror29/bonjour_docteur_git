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
            if (cons�quence.conditions == c)
            {
                return cons�quence.cons�quence;
            } else
            {
                return null;
            }
        }

        return null;
    }
}
