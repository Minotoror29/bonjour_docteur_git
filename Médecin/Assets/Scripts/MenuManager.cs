using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject main;
    public GameObject options;

    public void Jouer()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void Options()
    {
        main.SetActive(false);
        options.SetActive(true);
    }

    public void Retour()
    {
        options.SetActive(false);
        main.SetActive(true);
    }

    public void Quitter()
    {
        Application.Quit();
    }
}