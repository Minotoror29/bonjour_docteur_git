using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horloge : MonoBehaviour
{
    public bool heure;

    void Update()
    {
        if (heure == true)
        {
            gameObject.transform.Rotate(0, 0, -0.001f);
        }
        else
        {
            gameObject.transform.Rotate(0, 0, -0.01f);
        }
    }
}
