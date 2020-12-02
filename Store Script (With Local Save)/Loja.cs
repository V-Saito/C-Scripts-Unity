using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{
    private bool isOpenLoja = false;
    public Text yourcoinsText;
    public Animator capaceteAnim, armaduraAnim, armaAnim, lojaMenuAnim;
    public Button ReturnButton, ReturnButton2, ReturnButton3;
    public GameObject playerContainer;
    public Button BC1, BC2, BC3;
    public Button BA1, BA2, BA3;
    public Button BW1, BW2, BW3, BW4;
    public GameObject C1, C2, C3, C4, C5, C6, C7, C8, C9, C10;
    public GameObject W1, W2, W3, W4, W5, W6, W7, W8, W9, W10;
    public GameObject A11, A21, A31, A41, A51, A61, A71;
    public GameObject A12, A22, A32, A42, A52, A62, A72;
    public GameObject A13, A23, A33, A43, A53, A63, A73;
    public GameObject A14, A24, A34, A44, A54, A64, A74;
    public GameObject A15, A25, A35, A45, A55, A65, A75;
    public GameObject A16, A26, A36, A46, A56, A66, A76;
    public GameObject A17, A27, A37, A47, A57, A67, A77;

    private void Start()
    {
        ReturnButton.gameObject.SetActive(false);
        ReturnButton2.gameObject.SetActive(false);
        ReturnButton3.gameObject.SetActive(false);
        PlayerPrefs.SetInt("501", 1);
        PlayerPrefs.SetInt("601", 1);
        PlayerPrefs.SetInt("701", 1);
    }

    private void Update()
    {
        if (!isOpenLoja)
            return;
        
        yourcoinsText.text = PlayerPrefs.GetInt("Yourcoins").ToString();
        #region CComprados
        if (PlayerPrefs.GetInt("501") > 0)
        {
            BC1.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("502") > 0)
        {
            BC2.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("503") > 0)
        {
            BC3.gameObject.SetActive(false);
        }
        #endregion CComprados
        #region AComprados
        if (PlayerPrefs.GetInt("601") > 0)
        {
            BA1.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("602") > 0)
        {
            BA2.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("603") > 0)
        {
            BA3.gameObject.SetActive(false);
        }
        #endregion AComprados
        #region WCompradros
        if (PlayerPrefs.GetInt("701") > 0)
        {
            BW1.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("702") > 0)
        {
            BW2.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("703") > 0)
        {
            BW3.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("704") > 0)
        {
            BW4.gameObject.SetActive(false);
        }
        #endregion WComprados
    }

    #region MenuButtons
    public void OnOpenLojaButton()
    {
        isOpenLoja = true;
        lojaMenuAnim.SetTrigger("Show");
    }

    public void OnReturnButton()
    {
        lojaMenuAnim.SetTrigger("Show");
        capaceteAnim.SetTrigger("Hide");
        ReturnButton.gameObject.SetActive(false);
    }
    public void OnReturnButton2()
    {
        lojaMenuAnim.SetTrigger("Show");
        armaduraAnim.SetTrigger("Hide");
        ReturnButton2.gameObject.SetActive(false);
    }
    public void OnReturnButton3()
    {
        lojaMenuAnim.SetTrigger("Show");
        armaAnim.SetTrigger("Hide");
        ReturnButton3.gameObject.SetActive(false);
    }

    public void OnCapaceteButton()
    {
        capaceteAnim.SetTrigger("Show");
        lojaMenuAnim.SetTrigger("Hide");
        ReturnButton.gameObject.SetActive(true);
    }

    public void OnArmaduraButton()
    {
        armaduraAnim.SetTrigger("Show");
        lojaMenuAnim.SetTrigger("Hide");
        ReturnButton2.gameObject.SetActive(true);
    }

    public void OnArmaButton()
    {
        armaAnim.SetTrigger("Show");
        lojaMenuAnim.SetTrigger("Hide");
        ReturnButton3.gameObject.SetActive(true);
    }

    public void OnVoltarButton()
    {
        armaduraAnim.SetTrigger("Hide");
        armaAnim.SetTrigger("Hide");
        capaceteAnim.SetTrigger("Hide");
        lojaMenuAnim.SetTrigger("Show");
    }
    #endregion MenuButtons

    #region Itens

    #region Capacetes
    #region C1
    public void OnC1Button()
    {
        GameObject.FindGameObjectWithTag("Capacete").SetActive(false);
        C1.SetActive(true);
        if (PlayerPrefs.GetInt("501") == 1)
        {
            PlayerPrefs.SetInt("500", 501);
        }
        else
            return;
    }
    public void OnC1BuyButton()
    {
        if (PlayerPrefs.GetInt("Yourcoins") > 0)
        {
            PlayerPrefs.SetInt("Yourcoins", 0);
            PlayerPrefs.SetInt("501", 1);
        }
    }
    #endregion C1
    #region C2
    public void OnC2Button()
    {
        GameObject.FindGameObjectWithTag("Capacete").SetActive(false);
        C2.SetActive(true);
        if (PlayerPrefs.GetInt("502") == 1)
        {
            PlayerPrefs.SetInt("500", 502);
        }
        else
            return;  
    }
    public void OnC2BuyButton()
    {
        if (PlayerPrefs.GetInt("Yourcoins") > 2000)
        {
            int yc = PlayerPrefs.GetInt("Yourcoins");
            int p = 2000;
            PlayerPrefs.SetInt("Yourcoins", yc - p );
            PlayerPrefs.SetInt("502", 1);
        }
    }
    #endregion C2
    #region C3
    public void OnC3Button()
    {
        GameObject.FindGameObjectWithTag("Capacete").SetActive(false);
        C3.SetActive(true);
        if (PlayerPrefs.GetInt("503") == 1)
        {
            PlayerPrefs.SetInt("500", 503);
        }
        else
            return;
    }
    public void OnC3BuyButton()
    {
        if (PlayerPrefs.GetInt("Yourcoins") > 2000)
        {
            int yc = PlayerPrefs.GetInt("Yourcoins");
            int p = 2000;
            PlayerPrefs.SetInt("Yourcoins", yc - p);
            PlayerPrefs.SetInt("503", 1);
        }
    }
    #endregion C3
    #endregion Capacetes

    #region Armaduras
    #region A1
    public void OnA1Button()
    {
        GameObject.FindGameObjectWithTag("A1").SetActive(false);
        GameObject.FindGameObjectWithTag("A2").SetActive(false);
        GameObject.FindGameObjectWithTag("A3").SetActive(false);
        GameObject.FindGameObjectWithTag("A4").SetActive(false);
        GameObject.FindGameObjectWithTag("A5").SetActive(false);
        GameObject.FindGameObjectWithTag("A6").SetActive(false);
        GameObject.FindGameObjectWithTag("A7").SetActive(false);
        A11.SetActive(true);
        A21.SetActive(true);
        A31.SetActive(true);
        A41.SetActive(true);
        A51.SetActive(true);
        A61.SetActive(true);
        A71.SetActive(true);
        if (PlayerPrefs.GetInt("601") == 1)
        { 
            PlayerPrefs.SetInt("600", 601);
        }
        else
            return;
    }
    public void OnA1BuyButton()
    {
        if (PlayerPrefs.GetInt("Yourcoins") > 0)
        {
            PlayerPrefs.SetInt("Yourcoins", 0);
            PlayerPrefs.SetInt("601", 1);
        }
    }
    #endregion A1
    #region A2
    public void OnA2Button()
    {
        GameObject.FindGameObjectWithTag("A1").SetActive(false);
        GameObject.FindGameObjectWithTag("A2").SetActive(false);
        GameObject.FindGameObjectWithTag("A3").SetActive(false);
        GameObject.FindGameObjectWithTag("A4").SetActive(false);
        GameObject.FindGameObjectWithTag("A5").SetActive(false);
        GameObject.FindGameObjectWithTag("A6").SetActive(false);
        GameObject.FindGameObjectWithTag("A7").SetActive(false);
        A12.SetActive(true);
        A22.SetActive(true);
        A32.SetActive(true);
        A42.SetActive(true);
        A52.SetActive(true);
        A62.SetActive(true);
        A72.SetActive(true);
        if (PlayerPrefs.GetInt("602") == 1)
        {
            PlayerPrefs.SetInt("600", 602);
        }
        else
            return;
    }
    public void OnA2BuyButton()
    {
        if (PlayerPrefs.GetInt("Yourcoins") > 2000)
        {
            int yc = PlayerPrefs.GetInt("Yourcoins");
            int p = 2000;
            PlayerPrefs.SetInt("Yourcoins", yc - p);
            PlayerPrefs.SetInt("602", 1);
        }
    }
    #endregion A2
    #region A3
    public void OnA3Button()
    {
        GameObject.FindGameObjectWithTag("A1").SetActive(false);
        GameObject.FindGameObjectWithTag("A2").SetActive(false);
        GameObject.FindGameObjectWithTag("A3").SetActive(false);
        GameObject.FindGameObjectWithTag("A4").SetActive(false);
        GameObject.FindGameObjectWithTag("A5").SetActive(false);
        GameObject.FindGameObjectWithTag("A6").SetActive(false);
        GameObject.FindGameObjectWithTag("A7").SetActive(false);
        A13.SetActive(true);
        A23.SetActive(true);
        A33.SetActive(true);
        A43.SetActive(true);
        A53.SetActive(true);
        A63.SetActive(true);
        A73.SetActive(true);
        if (PlayerPrefs.GetInt("603") == 1)
        {
            PlayerPrefs.SetInt("600", 603);
        }
        else
            return;
    }
    public void OnA3BuyButton()
    {
        if (PlayerPrefs.GetInt("Yourcoins") > 2000)
        {
            int yc = PlayerPrefs.GetInt("Yourcoins");
            int p = 2000;
            PlayerPrefs.SetInt("Yourcoins", yc - p);
            PlayerPrefs.SetInt("603", 1);
        }
    }
    #endregion A3
    #endregion Armaduras

    #region Armas
    #region W1
    public void OnW1Button()
    {
        GameObject.FindGameObjectWithTag("Arma").SetActive(false);
        W1.SetActive(true);
        if (PlayerPrefs.GetInt("701") == 1)
        {
            PlayerPrefs.SetInt("700", 701);
        }
        else
            return;
    }
    public void OnW1BuyButton()
    {
        if (PlayerPrefs.GetInt("Yourcoins") > 0)
        {
            PlayerPrefs.SetInt("Yourcoins", 0);
            PlayerPrefs.SetInt("701", 1);
        }
    }
    #endregion C1
    #region W2
    public void OnW2Button()
    {
        GameObject.FindGameObjectWithTag("Arma").SetActive(false);
        W2.SetActive(true);
        if (PlayerPrefs.GetInt("702") == 1)
        {
            PlayerPrefs.SetInt("700", 702);
        }
        else
            return;
    }
    public void OnW2BuyButton()
    {
        if (PlayerPrefs.GetInt("Yourcoins") > 2000)
        {
            int yc = PlayerPrefs.GetInt("Yourcoins");
            int p = 2000;
            PlayerPrefs.SetInt("Yourcoins", yc - p);
            PlayerPrefs.SetInt("702", 1);
        }
    }

    #endregion W3
    #region W3
    public void OnW3Button()
    {
        GameObject.FindGameObjectWithTag("Arma").SetActive(false);
        W3.SetActive(true);
        if (PlayerPrefs.GetInt("703") == 1)
        {
            PlayerPrefs.SetInt("700", 703);
        }
        else
            return;
    }
    public void OnW3BuyButton()
    {
        if (PlayerPrefs.GetInt("Yourcoins") > 2000)
        {
            int yc = PlayerPrefs.GetInt("Yourcoins");
            int p = 2000;
            PlayerPrefs.SetInt("Yourcoins", yc - p);
            PlayerPrefs.SetInt("703", 1);
        }
    }
    #endregion W3
    #region W4
    public void OnW4Button()
    {
        GameObject.FindGameObjectWithTag("Arma").SetActive(false);
        W4.SetActive(true);
        if (PlayerPrefs.GetInt("704") == 1)
        {
            PlayerPrefs.SetInt("700", 704);
        }
        else
            return;
    }
    public void OnW4BuyButton()
    {
        if (PlayerPrefs.GetInt("Yourcoins") > 2000)
        {
            int yc = PlayerPrefs.GetInt("Yourcoins");
            int p = 2000;
            PlayerPrefs.SetInt("Yourcoins", yc - p);
            PlayerPrefs.SetInt("704", 1);
        }
    }
    #endregion W4
    #endregion Armas

    #endregion Itens
}
