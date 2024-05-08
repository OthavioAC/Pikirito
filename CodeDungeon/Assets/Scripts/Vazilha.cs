using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vazilha : MonoBehaviour
{

    public Sprite poteVazio;
    public Sprite poteCheio;
    public GameObject game;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(Input.GetMouseButtonDown(0))
        {
            game.GetComponent<Game>().EncherTijela();
            this.GetComponent<SpriteRenderer>().sprite = poteCheio;
        }
    }

    public void StartTijela(bool stado)
    {
        if(stado)
        {
            this.GetComponent<SpriteRenderer>().sprite = poteCheio;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = poteVazio;
        }
    }
}
