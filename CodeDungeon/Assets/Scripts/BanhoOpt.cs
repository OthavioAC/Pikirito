using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanhoOpt : MonoBehaviour
{
    public GameObject banho;
    public GameObject foodToggle;

    private void Start()
    {
        banho.SetActive(false);
    }

    public void ToggleBanho()
    {
        if(banho.activeSelf)
        {
            banho.SetActive(false);
        }
        else
        {
            foodToggle.SetActive(false);
            banho.SetActive(true);
        }
    }
}
