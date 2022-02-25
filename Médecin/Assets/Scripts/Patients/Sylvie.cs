using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sylvie : Patient
{
    public Phrase[] introduction_01;
    public Phrase[] symptomes_01;
    public Phrase[] conclusion_01;
    public Phrase[] conclusion_01_2;

    public Phrase[] introduction_02;
    public Phrase[] symptomes_02;
    public Phrase[] conclusion_02;
    public Phrase[] conclusion_02_2;

    public Sylvie()
    {
        nom = VILLAGEOIS.Sylvie;
        //maladie = MALADIES.Grippe;
        age = 9;
    }

    public override Phrase[] Introduction()
    {
        if (Ètat == 2)
        {
            return introduction_02;
        }

        return introduction_01;
    }

    public override Phrase[] Symptomes()
    {
        if (Ètat == 2)
        {
            return symptomes_02;
        }
        return symptomes_01;
    }

    public override Phrase[] Conclusion()
    {
        if (Ètat == 1)
        {
            if (sous…tat == 2)
                return conclusion_01_2;
            else
                return conclusion_01;
        } else
        {
            if (sous…tat == 2)
                return conclusion_02_2;
            else
                return conclusion_02;
        }
    }

    public override void Prescription(List<TRAITEMENTS> traitements)
    {
        if (Ètat == 1)
        {
            if (traitements.Count == 0)
            {
                sous…tat = 2;
            }
            else
            {
                sous…tat = 1;
            }
        }
    }
}
