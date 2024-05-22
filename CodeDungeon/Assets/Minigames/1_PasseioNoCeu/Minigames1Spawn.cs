using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Minigames1Spawn : MonoBehaviour
{

    public GameObject enemieObj;
    public GameObject imagemEmCima;
    public TextMeshProUGUI pointsText;
    public GameObject RestartBut;
    public GameObject BackBut;
    public int points = 0;
    public GameObject derrotaText;
    private String[] sinaisLetra = { "A","B","C","D","E","F","G","H","I","J","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
    public List<int> sinaisList = new List<int>();
    private float tempo = 0;
    private float tempoToSpawn = 0;


    public bool pausado = false;
    // Start is called before the first frame update
    void Start()
    {
        RestartBut.SetActive(false);
        BackBut.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = points.ToString();
        if (!pausado)
        {
            tempo += Time.deltaTime;

            if (sinaisList.Count > 0)
            {
                imagemEmCima.GetComponent<TextMeshProUGUI>().text = sinaisLetra[sinaisList[0]];
            }
            if (tempoToSpawn < 0)
            {
                var randi2 = UnityEngine.Random.Range(0, 24);
                var randi = UnityEngine.Random.Range(1, 3);


                var en1 = enemieObj;
                en1.GetComponent<Minigames1Enemie>().enId = 1;
                en1.GetComponent<Minigames1Enemie>().enIdCerto = randi;
                en1.GetComponent<Minigames1Enemie>().letraCerta = randi2;
                en1.GetComponent<Minigames1Enemie>().spawner = this.gameObject;
                Instantiate(en1, new Vector2(transform.position.x + 3, transform.position.y), Quaternion.identity);
                var en2 = enemieObj;
                en2.GetComponent<Minigames1Enemie>().enId = 2;
                en2.GetComponent<Minigames1Enemie>().enIdCerto = randi;
                en2.GetComponent<Minigames1Enemie>().letraCerta = randi2;
                en2.GetComponent<Minigames1Enemie>().spawner = this.gameObject;
                Instantiate(en2, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                var en3 = enemieObj;
                en3.GetComponent<Minigames1Enemie>().enId = 3;
                en3.GetComponent<Minigames1Enemie>().enIdCerto = randi;
                en3.GetComponent<Minigames1Enemie>().letraCerta = randi2;
                en3.GetComponent<Minigames1Enemie>().spawner = this.gameObject;
                Instantiate(en3, new Vector2(transform.position.x - 3, transform.position.y), Quaternion.identity);
                tempoToSpawn = 7;

                sinaisList.Add(randi2);
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
            else if (tempo > 15)
            {
                tempoToSpawn -= Time.deltaTime * 1.1f;
            }
            else
            {
                tempoToSpawn -= Time.deltaTime;
            }
        }
    }

    public void GameOver()
    {
        pausado = true;
        derrotaText.SetActive(true);
        RestartBut.SetActive(true);
        BackBut.SetActive(true);   
    }

    public void Restart()
    {

    }

    public void Back()
    {

    }
}
