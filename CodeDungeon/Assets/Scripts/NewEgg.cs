using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;

public class NewEgg : MonoBehaviour
{
    public GameObject game;
    public GameObject egg;
    public GameObject cenario;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void funcNewEgg()
    {
        if (game.GetComponent<Game>().piriquito != "Egg"&& game.GetComponent<Game>().piriquito != "Piriquito")
        {
            egg.GetComponent<Egg>().game = game;
            egg.GetComponent<Egg>().gameObjecte = game;
            egg.transform.position = new Vector2(0,0);  
            Instantiate(egg); 
            game.GetComponent<Game>().piriquito = "Egg";
            game.GetComponent<Game>().newEgg.enabled = false;
        }
    }
}
