using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Maladie")]
public class Maladie : ScriptableObject
{
    public string nom;
    public List<SYMPTOMES> symptomes;
}
