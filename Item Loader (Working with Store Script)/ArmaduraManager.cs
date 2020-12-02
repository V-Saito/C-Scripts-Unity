using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ArmaduraManager : MonoBehaviour
{
    public List<ArmaduraManager> A1;
    public List<ArmaduraManager> A2;
    private bool isEquiped = false;
    public void Start()
    {
        GameObject.FindGameObjectWithTag("Capacete").SetActive(false);
        if (PlayerPrefs.GetInt("600") == 601)
        {

        }
        if (PlayerPrefs.GetInt("600") == 602)
        {

        }
    }
}
