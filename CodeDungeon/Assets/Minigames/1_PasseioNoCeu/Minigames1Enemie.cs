using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;

public class Minigames1Enemie : MonoBehaviour
{

    public List<Sprite> moes = new List<Sprite>();
    public GameObject moeObj;

    public int enId = -1;
    public int enIdCerto = 0;
    public int letraCerta = -1;
    public GameObject spawner;
    public bool certo = false;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,20);
        if(enId==enIdCerto)
        {
            moeObj.GetComponent<SpriteRenderer>().sprite = moes[letraCerta];
            certo = true;
        }
        else
        {
            var randomMoe = UnityEngine.Random.Range(0, moes.Count);
            if(letraCerta ==  randomMoe)
            {
                certo = true;
            }
            moeObj.GetComponent<SpriteRenderer>().sprite = moes[randomMoe];
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if(!spawner.GetComponent<Minigames1Spawn>().pausado) transform.position = new Vector3(transform.position.x, transform.position.y-Time.deltaTime*3);
    }

    public void Destruir()
    {
        if(gameObject!=null)
        {
            Destroy(gameObject);
            spawner.GetComponent<Minigames1Spawn>().sinaisList.RemoveAt(0);
            spawner.GetComponent<Minigames1Spawn>().points += 1;

        }
    }


    public void Perder()
    {
        spawner.GetComponent<Minigames1Spawn>().GameOver();
    }
}
