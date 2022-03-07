using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Traitement")]
public class Traitement : ScriptableObject
{
    public string nom;
    public List<SYMPTOMES> symptomes;
}
