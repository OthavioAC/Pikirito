using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEgg : MonoBehaviour
{
    public GameObject game;
    public GameObject egg;

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
            Instantiate(egg);
            game.GetComponent<Game>().piriquito = "Egg";
            game.GetComponent<Game>().newEgg.enabled = false;
        }
    }
}
