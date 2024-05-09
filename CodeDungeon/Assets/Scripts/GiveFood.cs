using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class GiveFood : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler
{
    public GameObject game;
    public Camera cam;
    private bool blocked = false;
    public GameObject itemPuxado;
    private bool puxando = false;
    public GameObject activated;
    public GameObject foodCountText;

    public Image imagemCol;

    public int idFoodActual = 0;
    public List<GameObject> foods = new List<GameObject>();
    
    private void Start()
    {
        Instantiate(foods[0], activated.transform);
    }


    public void ResetFoodCount()
    {
        if (game.GetComponent<Game>().FoodCount.Count()>0)
        {
            foodCountText.GetComponent<TextMeshProUGUI>().text = game.GetComponent<Game>().FoodCount[idFoodActual].ToString();
        }
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
            if(Input.GetMouseButtonDown(0))
            {
                if (game.GetComponent<Game>().FoodCount[idFoodActual] > 0)
                {
                    itemPuxado = Instantiate(foods[idFoodActual], transform);
                    itemPuxado.SetActive(false);

                }
            }
            blocked = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        blocked = false;
        if(itemPuxado != null)
        {
            Destroy(itemPuxado);
            itemPuxado = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(itemPuxado != null)
        {
            puxando = true;
            activated.SetActive(false);
            itemPuxado.SetActive(true);
            itemPuxado.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(puxando)
        {
            if(game.GetComponent<Game>().piriquitoObj!=null)
            {
                var mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
                mousepos.z = 0;
                float distance = Vector2.Distance(mousepos, game.GetComponent<Game>().piriquitoObj.transform.position);
                if (distance < 2)
                {
                    game.GetComponent<Game>().lastComida = DateTime.Now;
                    game.GetComponent<Game>().FoodCount[idFoodActual] -= 1;
                    ResetFoodCount();
                }
                puxando = false;
                activated.SetActive(true);
            }
        }
    }
}
