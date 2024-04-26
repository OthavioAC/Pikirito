using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BanhoOpt : MonoBehaviour
{
    public GameObject banho;
    public GameObject banhoObj;
    public GameObject food;
    public GameObject foodObj;

    private void Start()
    {
        banhoObj.GetComponent<Banho>().imagemCol.enabled = false;
        banho.SetActive(false);
    }

    public void ToggleBanho()
    {
        banhoObj.GetComponent<Banho>().imagemCol.enabled = false;
        foodObj.GetComponent<GiveFood>().imagemCol.enabled = false;

        if (banho.activeSelf)
        {
            banho.SetActive(false);
        }
        else
        {
            food.SetActive(false);
            banho.SetActive(true);
            banhoObj.GetComponent<Banho>().imagemCol.enabled = true;
        }
    }
}
