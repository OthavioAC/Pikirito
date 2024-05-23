using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigames1Nuvem : MonoBehaviour
{

    public GameObject spawner;

    public float randomspd = 1f;
    // Start is called before the first frame update
    void Start()
    { 
        Destroy(gameObject, 120);
        randomspd = Random.Range(0.5f, 2f);
        GetComponent<SpriteRenderer>().sortingOrder = ((int)(randomspd*10)) - 100;
    }

    // Update is called once per frame
    void Update()
    {

        if (!spawner.GetComponent<Minigames1Spawn>().pausado) transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * randomspd, randomspd);
    }
}
