using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    public GameObject label_moedas;
    public Animator anim;

    public float velocidade = 5f; // Velocidade de movimento
    public Vector2 limiteMin; // Canto inferior esquerdo da área
    public Vector2 limiteMax; // Canto superior direito da área

    public string state = "Idle";


    private float idleTime = 0;
    private float idleTimeMax = 4;
    private Vector2 lastPos = new Vector2 (0, 0);
    private Vector2 walkingTo = new Vector2(0,0);

    private Vector2 destinoAleatorio;


    private string stat_Comida = "Cheio";
    private string stat_Diversao = "Muito Feliz";
    private string stat_Agua = "Cheio";
    private string stat_Sujeira = "Limpo";
    private string stat_Energia = "Animado";

    private DateTime lastComida;
    private DateTime lastDiversao;
    private DateTime lastAgua;
    private DateTime lastSujeira;
    private DateTime lastEnergia;

    private void Start()
    {
        transform.position = new Vector2(0, 0);
        if(lastComida.Year==1)
        {
            DateTime date = DateTime.Now;
            lastComida = date.AddHours(-3);
            lastDiversao = date.AddHours(-3);
            lastAgua = date.AddHours(-3);
            lastSujeira = date.AddHours(-3);
            lastEnergia = date.AddHours(-3);
        }

    }

    private void Update()
    {
        DateTime dat = DateTime.Now;

        DateTime datSemComida = dat.AddTicks(-lastComida.Ticks);
        if (datSemComida.Hour < 3)
        {
            stat_Comida = "Gordo";
        }
        if (datSemComida.Hour >= 3)
        {
            stat_Comida = "Cheio";
        }
        if (datSemComida.Hour > 6)
        {
            stat_Comida = "Neutro";
        }
        if (datSemComida.Hour > 12)
        {
            stat_Comida = "Com Fome";
        }
        if (datSemComida.Hour > 24)
        {
            stat_Comida = "Esfomeado";
        }
        if (datSemComida.Hour > 72)
        {
            stat_Comida = "Morto - Fome";
        }

        DateTime datSemDiversao = dat.AddTicks(-lastDiversao.Ticks);
        if (datSemDiversao.Hour < 3)
        {
            stat_Diversao = "Excitado";
        }
        if (datSemDiversao.Hour >= 3)
        {
            stat_Diversao = "Feliz";
        }
        if (datSemDiversao.Hour >= 8)
        {
            stat_Diversao = "Neutro";
        }
        if (datSemDiversao.Hour >= 16)
        {
            stat_Diversao = "Triste";
        }
        if (datSemDiversao.Hour >= 32)
        {
            stat_Diversao = "Depressivo";
        }









        if (state == "Idle")
        {
            if (idleTime <= idleTimeMax)
            {
                anim.SetBool("Idle", true);
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
                    anim.SetBool("Idle", false);
                    var posx = transform.position.x - destinoAleatorio.x;
                    var posy = transform.position.y - destinoAleatorio.y;
                    anim.SetFloat("MovementX", -posx);
                    anim.SetFloat("MovementY", -posy);
                    transform.position = Vector2.MoveTowards(transform.position, destinoAleatorio, velocidade * Time.deltaTime);
                }
            }
        }
    }

    private Vector2 PosRandom()
    {
        float posx = Random.Range(-20f,20f);
        float yrange = (20-math.abs(posx))/2;
        float posy = Random.Range(-yrange, yrange);
        return new Vector2(posx,posy);
    }
}
