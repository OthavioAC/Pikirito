using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigames1Spawn : MonoBehaviour
{

    public GameObject enemieObj;
    private float tempo = 0;
    private float tempoToSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;


        if(tempoToSpawn < 0)
        {
            var randi2 = Random.Range(0, 24);
            var randi = Random.Range(0, 2);


            var en1 = enemieObj;
            en1.GetComponent<Minigames1Enemie>().enId = 1;
            en1.GetComponent<Minigames1Enemie>().enIdCerto = randi;
            en1.GetComponent<Minigames1Enemie>().letraCerta = randi2;
            Instantiate(en1, new Vector2(transform.position.x + 3, transform.position.y), Quaternion.identity);
            var en2 = enemieObj;
            en2.GetComponent<Minigames1Enemie>().enId = 2;
            en2.GetComponent<Minigames1Enemie>().enIdCerto = randi;
            en2.GetComponent<Minigames1Enemie>().letraCerta = randi2;
            Instantiate(en2, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            var en3 = enemieObj;
            en3.GetComponent<Minigames1Enemie>().enId = 3;
            en3.GetComponent<Minigames1Enemie>().enIdCerto = randi;
            en3.GetComponent<Minigames1Enemie>().letraCerta = randi2;
            Instantiate(en3, new Vector2(transform.position.x - 3, transform.position.y), Quaternion.identity);
            tempoToSpawn = 5;
        }

        if (tempo > 150)
        {
            tempoToSpawn -= Time.deltaTime * 1.8f;
        }
        else if (tempo > 110)
        {
            tempoToSpawn -= Time.deltaTime * 1.6f;
        }
        else if (tempo > 90)
        {
            tempoToSpawn -= Time.deltaTime * 1.5f;
        }
        else if (tempo > 70)
        {
            tempoToSpawn -= Time.deltaTime * 1.4f;
        }
        else if (tempo > 50)
        {
            tempoToSpawn -= Time.deltaTime * 1.3f;
        }
        else if (tempo > 30)
        {
            tempoToSpawn -= Time.deltaTime * 1.2f;
        }
        else if(tempo>15)
        {
            tempoToSpawn -= Time.deltaTime * 1.1f;
        }
        else
        {
            tempoToSpawn -= Time.deltaTime;
        }
    }
}
