using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    [SerializeField] GameObject pageMaladies;
    [SerializeField] GameObject pageTraitements;
    [SerializeField] GameObject pageOptions;
    [SerializeField] RectTransform boutonMaladies;
    [SerializeField] RectTransform boutonTraitements;
    [SerializeField] RectTransform boutonOptions;

    event Action<int> OnChangementDePage;

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

    void ChangementDePage(int page)
    {
        pages[pageActuelle].SetActive(false);
        pageActuelle = page;
        pages[pageActuelle].SetActive(true);
        Book.pitch = UnityEngine.Random.Range(0.95f, 1.05f);
        Book.Play();

        if (pageActuelle < pageMaladies.transform.GetSiblingIndex())
        {
            boutonMaladies.anchoredPosition = new Vector2(330, boutonMaladies.anchoredPosition.y);
        } else
        {
            boutonMaladies.anchoredPosition = new Vector2(-330, boutonMaladies.anchoredPosition.y);

        }

        if (pageActuelle < pageTraitements.transform.GetSiblingIndex())
        {
            boutonTraitements.anchoredPosition = new Vector2(330, boutonTraitements.anchoredPosition.y);
        } else
        {
            boutonTraitements.anchoredPosition = new Vector2(-330, boutonTraitements.anchoredPosition.y);
        }

        if (pageActuelle < pageOptions.transform.GetSiblingIndex())
        {
            boutonOptions.anchoredPosition = new Vector2(330, boutonOptions.anchoredPosition.y);
        }
        else
        {
            boutonOptions.anchoredPosition = new Vector2(-330, boutonOptions.anchoredPosition.y);
        }
    }

    public void Suivant()
    {
        if (pageActuelle == pages.Count - 1)
            return;

        OnChangementDePage?.Invoke(pageActuelle + 1);

    }

    public void Précédent()
    {
        if (pageActuelle == 0)
            return;

        OnChangementDePage?.Invoke(pageActuelle - 1);
    }

    public void Maladies()
    {
        OnChangementDePage?.Invoke(pageMaladies.transform.GetSiblingIndex());
    }

    public void Traitements()
    {
        OnChangementDePage?.Invoke(pageTraitements.transform.GetSiblingIndex());
    }

    public void Options()
    {
        OnChangementDePage?.Invoke(pageOptions.transform.GetSiblingIndex());
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

    private void OnEnable()
    {
        OnChangementDePage += ChangementDePage;
    }

    private void OnDisable()
    {
        OnChangementDePage -= ChangementDePage;

    }
}
