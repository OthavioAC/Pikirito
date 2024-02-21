using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer tileRenderer;
    [SerializeField] private GameObject highlight;

    [SerializeField] private GameObject objeto;

    private SideBlock blockImage;
    public void Init(bool isOffset, GameObject gameObject)
    {
        tileRenderer.color = isOffset ? offsetColor : baseColor;
        blockImage = gameObject.GetComponent<SideBlock>();
    }

    private void OnMouseEnter()
    {
        //Debug.Log(blockImage.GetBlocked());
        if(!blockImage.GetBlocked()) highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

}
