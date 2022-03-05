using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    public Villageois sylvie;

    public List<Villageois> village;

    public void UpdateVillage()
    {
        village[0] = sylvie;
    }
}
