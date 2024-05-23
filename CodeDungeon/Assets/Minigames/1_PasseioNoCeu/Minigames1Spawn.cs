using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Minigames1Spawn : MonoBehaviour
{

    public GameObject telaMinijogos;
    public GameObject minigame;

    public List<Sprite> nuvemSprites = new List<Sprite>();

    public bool comecou = false;
    public float spawnNuvem = 0f;
    public GameObject nuvemObj;
    public TextMeshProUGUI minigame1;
    public GameObject game;
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
    public List<GameObject> inimigos = new List<GameObject>();
    public List<GameObject> nuvens = new List<GameObject>();


    public bool pausado = false;
    // Start is called before the first frame update
    void Start()
    {
        RestartBut.SetActive(false);
        BackBut.SetActive(false);
        nuvemObj.GetComponent<Minigames1Nuvem>().spawner = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = points.ToString();
        if (!pausado)
        {

            if(!comecou)
            {
                var initNuvem = 0;
                do
                {
                    var nuvemOb = Instantiate(nuvemObj, new Vector2(transform.position.x + UnityEngine.Random.Range(-7f, 7f), transform.position.y - UnityEngine.Random.Range(0f, 50f)), Quaternion.identity);
                    var randomSpr = UnityEngine.Random.Range(0, 3);
                    nuvemOb.GetComponent<SpriteRenderer>().sprite = nuvemSprites[randomSpr];
                    if (UnityEngine.Random.Range(0, 2) == 0)
                    {
                        nuvemOb.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    nuvens.Add(nuvemOb);
                    initNuvem += 1;
                } while (initNuvem < 50);
                comecou = true;
            }
            tempo += Time.deltaTime;
            spawnNuvem += Time.deltaTime;

            if (spawnNuvem > 1)
            {
                spawnNuvem = 0;
                var nuvem = Instantiate(nuvemObj, new Vector2(transform.position.x + UnityEngine.Random.Range(-7f, 7f), transform.position.y), Quaternion.identity);
                var randomSpr = UnityEngine.Random.Range(0,3);
                nuvem.GetComponent<SpriteRenderer>().sprite = nuvemSprites[randomSpr];
                if (UnityEngine.Random.Range(0,2)==0)
                {
                    nuvem.GetComponent<SpriteRenderer>().flipX = true;
                }
                nuvens.Add(nuvem);
            }

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
                var en1ins = Instantiate(en1, new Vector2(transform.position.x + 3, transform.position.y), Quaternion.identity);
                inimigos.Add(en1ins);
                var en2 = enemieObj;
                en2.GetComponent<Minigames1Enemie>().enId = 2;
                en2.GetComponent<Minigames1Enemie>().enIdCerto = randi;
                en2.GetComponent<Minigames1Enemie>().letraCerta = randi2;
                en2.GetComponent<Minigames1Enemie>().spawner = this.gameObject;
                var en2ins = Instantiate(en2, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                inimigos.Add(en2ins);
                var en3 = enemieObj;
                en3.GetComponent<Minigames1Enemie>().enId = 3;
                en3.GetComponent<Minigames1Enemie>().enIdCerto = randi;
                en3.GetComponent<Minigames1Enemie>().letraCerta = randi2;
                en3.GetComponent<Minigames1Enemie>().spawner = this.gameObject;
                var en3ins = Instantiate(en3, new Vector2(transform.position.x - 3, transform.position.y), Quaternion.identity);
                inimigos.Add(en3ins);
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
        else
        {
            comecou = false;
        }
    }

    private void OnBecameVisible()
    {
        pausado = false;
    }

    private void OnEnable()
    {
        pausado = false;
    }

    public void GameOver()
    {
        if(game.GetComponent<Game>().recordeMinigame1<points)
        {
            game.GetComponent<Game>().recordeMinigame1 = points;
        }
        pausado = true;
        derrotaText.SetActive(true);
        RestartBut.SetActive(true);
        BackBut.SetActive(true);   
    }

    public void Restart()
    {
        points = 0;
        tempo = 0;
        pausado = false;
        derrotaText.SetActive(false);
        RestartBut.SetActive(false);
        BackBut.SetActive(false);
        foreach (GameObject inimigo in inimigos)
        {
            if(inimigo!=null) Destroy(inimigo);
        }
        foreach (GameObject nuv in nuvens)
        {
            if (nuv != null) Destroy(nuv);
        }
        inimigos.Clear();
        sinaisList.Clear();
    }

    public void Back()
    {
        minigame1.text = game.GetComponent<Game>().recordeMinigame1.ToString();
        pausado = true;
        points = 0;
        tempo = 0;
        derrotaText.SetActive(false);
        RestartBut.SetActive(false);
        BackBut.SetActive(false);
        foreach (GameObject inimigo in inimigos)
        {
            if (inimigo != null) Destroy(inimigo);
        }
        foreach (GameObject nuv in nuvens)
        {
            if (nuv != null) Destroy(nuv);
        }
        inimigos.Clear();
        sinaisList.Clear();
        minigame.SetActive(false);
        telaMinijogos.SetActive(true);
    }
}
