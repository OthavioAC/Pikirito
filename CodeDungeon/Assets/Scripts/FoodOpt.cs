using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodOpt : MonoBehaviour
{
    public GameObject foodObj;
    public GameObject GiveFood;
    public GameObject banhoToggle;

    void Start()
    {
        foodObj.SetActive(false);
    }

    public void ToggleFood() 
    {
        if(foodObj.activeSelf)
        {
            foodObj.SetActive(false);
        }
        else
        {
            banhoToggle.SetActive(false);
            GiveFood.GetComponent<GiveFood>().ResetFoodCount();
            foodObj.SetActive(true);
        }
    }
}
