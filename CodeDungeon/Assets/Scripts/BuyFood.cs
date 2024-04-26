using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Unity.Collections.AllocatorManager;

public class BuyFood : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public GameObject game;
    public GameObject giveFood;
    public GameObject activated;
    private bool blocked = false;

    private int[] foodPrices = new int[1];

    private void Start()
    {
        foodPrices[0] = 1; //Cenoura
    }
    public bool GetBlocked()
    {
        return blocked;
    }
    public void SetBlocked(bool bloc)
    {
        blocked = bloc;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!activated.activeSelf)
        {

        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                var idFood = giveFood.GetComponent<GiveFood>().idFoodActual;
                if (game.GetComponent<Game>().moedas >= foodPrices[idFood])
                {
                    game.GetComponent<Game>().FoodCount[idFood] += 1;
                    game.GetComponent<Game>().moedas -= foodPrices[idFood];
                    giveFood.GetComponent<GiveFood>().ResetFoodCount();
                }
            }
            blocked = true;
        }

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        blocked = false;

    }
}
