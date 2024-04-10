using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    public GameObject label_moedas;

    public float velocidade = 5f; // Velocidade de movimento
    public Vector2 limiteMin; // Canto inferior esquerdo da área
    public Vector2 limiteMax; // Canto superior direito da área

    public string state = "Idle";


    private float idleTime = 0;
    private float idleTimeMax = 4;
    private Vector2 walkingTo = new Vector2(0,0);

    private Vector2 destinoAleatorio;


    private int moedas = 0;
    private void Start()
    {
        transform.position = new Vector2(0, 0);
    }

    private void Update()
    {
        if (state == "Idle")
        {
            if (idleTime <= idleTimeMax)
            {
                idleTime += Time.deltaTime;
            }
            else
            {
                if (Vector2.Distance(transform.position, destinoAleatorio) < 0.1f)
                {
                    idleTime = 0;
                    destinoAleatorio = PosRandom();
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, destinoAleatorio, velocidade * Time.deltaTime);
                }
            }
        }
    }

    private Vector2 PosRandom()
    {
        return new Vector2(Random.Range(limiteMin.x, limiteMax.x), Random.Range(limiteMin.y, limiteMax.y));
    }
}
