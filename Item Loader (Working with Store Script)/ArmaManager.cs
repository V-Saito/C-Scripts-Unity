using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManager : MonoBehaviour
{
    public GameObject W1, W2, W3, W4, W5, W6, W7, W8, W9, W10;
    void Start()
    {
        if (PlayerPrefs.GetInt("700") <= 701)
        {
            W1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("700") == 702)
        {
            W2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("700") == 703)
        {
            W3.SetActive(true);
        }
        if (PlayerPrefs.GetInt("700") == 704)
        {
            W4.SetActive(true);
        }
        if (PlayerPrefs.GetInt("700") == 705)
        {
            W5.SetActive(true);
        }
        if (PlayerPrefs.GetInt("700") == 706)
        {
            W6.SetActive(true);
        }
        if (PlayerPrefs.GetInt("700") == 707)
        {
            W7.SetActive(true);
        }
        if (PlayerPrefs.GetInt("700") == 708)
        {
            W8.SetActive(true);
        }
        if (PlayerPrefs.GetInt("700") == 709)
        {
            W9.SetActive(true);
        }
        if (PlayerPrefs.GetInt("700") == 710)
        {
            W10.SetActive(true);
        }
    }
}
