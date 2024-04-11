using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public GameObject eggIdle;
    public int clicks = 0;
    public GameObject game;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(clicks>=7)
        {
            Chocar();
        }
    }

    void OnMouseDown()
    {
        eggIdle.GetComponent<Animator>().Play("EggClicked", 0, 0f);
        clicks += 1;
    }

    private void Chocar()
    {
        //game.GetComponent<Game>().piriquito = piriquito.gameObject;
        clicks = -999;
        Destroy(this.gameObject);
    }
}
