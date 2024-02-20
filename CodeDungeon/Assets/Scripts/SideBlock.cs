using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SideBlock : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool blocked = false;
    public bool GetBlocked()
    {
        return blocked;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        blocked = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        blocked = false;
    }
}
