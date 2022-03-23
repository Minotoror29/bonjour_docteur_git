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
            gameObject.transform.Rotate(0, 0, -0.004f);
        }
        else
        {
            gameObject.transform.Rotate(0, 0, -0.04f);
        }
    }

    public void Reset()
    {
        if (heure == true)
        {
            gameObject.transform.rotation = new Quaternion(0, 0, 0.707106829f, -0.707106829f);
        }
        else 
        {
            gameObject.transform.rotation = new Quaternion(0, 0, 0.707106829f, 0.707106829f);
        }
    }
}
