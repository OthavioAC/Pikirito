using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodOpt : MonoBehaviour
{
    public GameObject banho;
    public GameObject banhoObj;
    public GameObject food;
    public GameObject foodObj;

    void Start()
    {
        foodObj.GetComponent<GiveFood>().imagemCol.enabled = false;
        food.SetActive(false);
    }

    public void ToggleFood() 
    {
        banhoObj.GetComponent<Banho>().imagemCol.enabled = false;
        foodObj.GetComponent<GiveFood>().imagemCol.enabled = false;

        if (food.activeSelf)
        {
            food.SetActive(false);
        }
        else
        {
            banho.SetActive(false);
            foodObj.GetComponent<GiveFood>().ResetFoodCount();
            foodObj.GetComponent<GiveFood>().imagemCol.enabled = true;
            food.SetActive(true);
        }
    }
}
