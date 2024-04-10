using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEgg : MonoBehaviour
{
    public GameObject Game;
    public GameObject Egg;

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
        Instantiate(Egg);
        Game.GetComponent<Game>().piriquito = Egg;
        Game.GetComponent<Game>().newEgg.enabled = false;
    }
}
