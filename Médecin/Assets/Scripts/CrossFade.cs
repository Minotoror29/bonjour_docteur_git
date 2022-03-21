using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFade : MonoBehaviour
{
    public void Nuit()
    {
        FindObjectOfType<GameManager>().Nuit();
    }
}
