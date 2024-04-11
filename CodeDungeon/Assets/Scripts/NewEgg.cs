using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEgg : MonoBehaviour
{
    public GameObject game;
    public GameObject egg;
    public GameObject textOvo;

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

        egg.GetComponent<Egg>().game = game;
        Instantiate(egg);
        game.GetComponent<Game>().piriquito = egg;
        game.GetComponent<Game>().newEgg.enabled = false;
        textOvo.SetActive(false);
    }
}
