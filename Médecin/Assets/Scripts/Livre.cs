using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livre : MonoBehaviour
{
    // Son
    private GameObject PartIG;
    private GameObject PartIIG;
    private GameObject PartIIIG;
    private GameObject PartID;
    private GameObject PartIID;
    private GameObject PartIIID;
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
        PartID = GameObject.Find("Partie I D");
        PartIID = GameObject.Find("Partie II D");
        PartIIID = GameObject.Find("Partie III D");
        PartIG = GameObject.Find("Partie I G");
        PartIIG = GameObject.Find("Partie II G");
        PartIIIG = GameObject.Find("Partie III G");
}

    public void PartieI()
    {
        pages[pageActuelle].SetActive(false);
        pageActuelle = 1;
        pages[pageActuelle].SetActive(true);
        Book.pitch = Random.Range(0.95f, 1.05f);
        Book.Play();

    }

    public void PartieII()
    {
        pages[pageActuelle].SetActive(false);
        pageActuelle = 14;
        pages[pageActuelle].SetActive(true);
        Book.pitch = Random.Range(0.95f, 1.05f);
        Book.Play();
    }

    public void PartieIII()
    {
        pages[pageActuelle].SetActive(false);
        pageActuelle = 26;
        pages[pageActuelle].SetActive(true);
        Book.pitch = Random.Range(0.95f, 1.05f);
        Book.Play();
    }

    public void Suivant()
    {
        if (pageActuelle == pages.Count - 1)
            return;

        pages[pageActuelle].SetActive(false);
        pageActuelle += 1;
        pages[pageActuelle].SetActive(true);
        // Son
        Book.pitch = Random.Range(0.95f, 1.05f);
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
        Book.pitch = Random.Range(0.95f, 1.05f);
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
                PartIG.SetActive(false);
                PartIIG.SetActive(false);
                PartIIIG.SetActive(false);
                PartID.SetActive(true);
                PartIID.SetActive(true);
                PartIIID.SetActive(true);
            }
            else
            {
                Suiv.SetActive(false);
                PartIG.SetActive(true);
                PartIIG.SetActive(true);
                PartIIIG.SetActive(true);
                PartID.SetActive(false);
                PartIID.SetActive(false);
                PartIIID.SetActive(false);
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
                PartIG.SetActive(true);
                PartIIG.SetActive(false);
                PartIIIG.SetActive(false);
                PartID.SetActive(false);
                PartIID.SetActive(true);
                PartIIID.SetActive(true);
            }
            else if (pageActuelle <= 25)
            {
                Pages.sprite = Bk03;
                PartIG.SetActive(true);
                PartIIG.SetActive(true);
                PartIIIG.SetActive(false);
                PartID.SetActive(false);
                PartIID.SetActive(false);
                PartIIID.SetActive(true);
            }
            else if (pageActuelle == 26)
            {
                Pages.sprite = Bk04;
                PartIG.SetActive(true);
                PartIIG.SetActive(true);
                PartIIIG.SetActive(true);
                PartID.SetActive(false);
                PartIID.SetActive(false);
                PartIIID.SetActive(false);
            }
        }
    }
}
