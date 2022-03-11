using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prescription : MonoBehaviour
{
    public Sprite List01;
    public Sprite List02;
    public Sprite List03;
    public Sprite List04;
    private Sprite[] Sprites;

    public List<Traitement> traitements;

    private void Awake()
    {
        Sprites = new Sprite[]
        {
            List01,
            List02,
            List03,
            List04,
        };
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Sprites[Random.Range(0, Sprites.Length)];
    
    }
}
