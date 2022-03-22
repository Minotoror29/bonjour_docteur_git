using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public List<Villageois> village;
}
