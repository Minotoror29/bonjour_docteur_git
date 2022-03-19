using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livre : MonoBehaviour
{
    // Son
    private GameObject Suiv;
    private GameObject Prec;
    private AudioSource Book;
    private SpriteRenderer Pages;
    public Sprite Bk01;
    public Sprite Bk02;
    public Sprite Bk03;
    public Sprite Bk04;

    [SerializeField] List<GameObject> pages;
    int pageActuelle;

    private void Start()
    {
        pageActuelle = pages.IndexOf(pages[0]);
        Book = GameObject.Find("LIVRE").GetComponent<AudioSource>();
        Pages = GameObject.Find("LIVRE").GetComponentInChildren<SpriteRenderer>();
        Bk01 = Resources.Load<Sprite>("01_Visuals/spr_Book01");
        Bk02 = Resources.Load<Sprite>("01_Visuals/spr_Book02");
        Bk03 = Resources.Load<Sprite>("01_Visuals/spr_Book03");
        Bk04 = Resources.Load<Sprite>("01_Visuals/spr_Book04");
        Suiv = GameObject.Find("Suivant");
        Prec = GameObject.Find("Precedent");
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

    public void Update()
    {
        if ( pageActuelle == 0 || pageActuelle == pages.Count -1)
        {
            Pages.sprite = Bk01;
            if (pageActuelle == pages.Count - 1 && Pages.flipX == false)
            {
                Pages.flipX = true;
            };

            if (pageActuelle == 0)
            {
                Prec.SetActive(false);
            }
            else
            {
                Suiv.SetActive(false);
            }
        }
        if ( pageActuelle != 0 && pageActuelle != pages.Count -1)
        {
            if (Pages.flipX == true)
            {
                Pages.flipX = false;
            };

            if (Prec.activeSelf == false)
            {
                Prec.SetActive(true);
            };

            if (Suiv.activeSelf == false)
            {
                Suiv.SetActive(true);
            }

            if (pageActuelle <= 13)
            {
                Pages.sprite = Bk02;
            }
            else if (pageActuelle <= 25)
            {
                Pages.sprite = Bk03;
            }
            else if (pageActuelle == 26)
            {
                Pages.sprite = Bk04;
            }
        }
    }
}
