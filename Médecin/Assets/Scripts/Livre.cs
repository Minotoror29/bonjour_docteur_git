using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livre : MonoBehaviour
{
    // Son
    private AudioSource Book;

    [SerializeField] List<GameObject> pages;
    int pageActuelle;

    private void Start()
    {
        pageActuelle = pages.IndexOf(pages[0]);
        Book = GameObject.Find("LIVRE").GetComponent<AudioSource>();
    }

    public void Suivant()
    {
        if (pageActuelle == pages.Count - 1)
            return;

        pages[pageActuelle].SetActive(false);
        pageActuelle += 1;
        pages[pageActuelle].SetActive(true);
        // Son
        Book.Play();

    }

    public void Précédent()
    {
        if (pageActuelle == 0)
            return;

        pages[pageActuelle].SetActive(false);
        pageActuelle -= 1;
        pages[pageActuelle].SetActive(true);
        // Son
        Book.Play();
    }
}
