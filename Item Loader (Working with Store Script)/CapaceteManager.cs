using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapaceteManager : MonoBehaviour
{
    public GameObject C1, C2, C3, C4, C5, C6, C7, C8, C9, C10;
    void Start()
    {
        if (PlayerPrefs.GetInt("500") <= 501)
        {
            C1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("500") == 502)
        {
            C2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("500") == 503)
        {
            C3.SetActive(true);
        }
        if (PlayerPrefs.GetInt("500") == 504)
        {
            C4.SetActive(true);
        }
        if (PlayerPrefs.GetInt("500") == 505)
        {
            C5.SetActive(true);
        }
        if (PlayerPrefs.GetInt("500") == 506)
        {
            C6.SetActive(true);
        }
        if (PlayerPrefs.GetInt("500") == 507)
        {
            C7.SetActive(true);
        }
        if (PlayerPrefs.GetInt("500") == 508)
        {
            C8.SetActive(true);
        }
        if (PlayerPrefs.GetInt("500") == 509)
        {
            C9.SetActive(true);
        }
        if (PlayerPrefs.GetInt("500") == 510)
        {
            C10.SetActive(true);
        }
    }
}
