using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Conclusion : MonoBehaviour
{
    public Text marguerite;
    public Text ren�;
    public Text sylvie;

    Village village;

    private void Start()
    {
        village = FindObjectOfType<Village>();

        sylvie.text = village.village[0].conclusion;
        ren�.text = village.village[1].conclusion;
        marguerite.text = village.village[2].conclusion;
    }

    public void End()
    {
            SceneManager.LoadScene("MainMenu");
    }
}
