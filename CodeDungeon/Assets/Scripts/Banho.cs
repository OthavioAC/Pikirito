using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class Banho : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler
{
    
    public GameObject itemPuxado;
    public GameObject banho;
    public GameObject game;
    public Camera cam;
    private bool blocked = false;

    public Image imagemCol;

    private bool puxando = false;
    public GameObject sabonete;

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
        if (!banho.activeSelf)
        {

        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                itemPuxado = Instantiate(sabonete, transform);
                itemPuxado.SetActive(false);
            }
            blocked = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        blocked = false;
        if (itemPuxado != null)
        {
            Destroy(itemPuxado);
            itemPuxado = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (itemPuxado != null)
        {
            if (game.GetComponent<Game>().piriquitoObj != null)
            {
                var mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
                mousepos.z = 0;
                float distance = Vector3.Distance(mousepos, game.GetComponent<Game>().piriquitoObj.transform.position);
                if (distance < 2)
                {
                    game.GetComponent<Game>().piriquitoObj.GetComponent<Character>().banhoPart.SetActive(true);
                    game.GetComponent<Game>().lastSujeira = DateTime.Now;
                }
                else
                {
                    game.GetComponent<Game>().piriquitoObj.GetComponent<Character>().banhoPart.SetActive(false);
                }
            }
            puxando = true;
            banho.SetActive(false);
            itemPuxado.SetActive(true);
            itemPuxado.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (puxando)
        {
            if (game.GetComponent<Game>().piriquitoObj != null)
            {
                game.GetComponent<Game>().piriquitoObj.GetComponent<Character>().banhoPart.SetActive(false);
            }
            puxando = false;
            banho.SetActive(true);
        }
    }



}
