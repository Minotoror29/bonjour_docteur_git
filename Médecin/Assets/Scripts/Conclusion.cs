using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Conclusion : MonoBehaviour
{
    public Text marguerite;
    public Text rené;
    public Text sylvie;

    Village village;

    [TextArea(3, 10)] public string marguerite_01;
    [TextArea(3, 10)] public string marguerite_02;
    [TextArea(3, 10)] public string rené_01;
    [TextArea(3, 10)] public string rené_02;
    [TextArea(3, 10)] public string sylvie_01;
    [TextArea(3, 10)] public string sylvie_02;

    private void Start()
    {
        village = FindObjectOfType<Village>();

        
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
