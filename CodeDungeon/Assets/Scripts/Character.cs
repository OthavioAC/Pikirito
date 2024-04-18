using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    public GameObject gameObject;
    public Game gameScript;
    public GameObject label_moedas;
    public Animator anim;
    public GameObject bosta;

    public float velocidade = 5f; // Velocidade de movimento
    public Vector2 limiteMin; // Canto inferior esquerdo da área
    public Vector2 limiteMax; // Canto superior direito da área

    public string state = "Idle";


    private float idleTime = 0;
    private float idleTimeMax = 4;
    private Vector2 lastPos = new Vector2(0, 0);
    private Vector2 walkingTo = new Vector2(0, 0);

    private Vector2 destinoAleatorio;


    [SerializeField] private string stat_Comida = "Cheio";
    [SerializeField] private string stat_Diversao = "Muito Feliz";
    [SerializeField] private string stat_Agua = "Cheio";
    [SerializeField] private string stat_Sujeira = "Limpo";


    private void Start()
    {
        gameScript = gameObject.GetComponent<Game>();
        transform.position = new Vector2(0, 0);
        if (gameScript.lastComida.Year == 1)
        {
            DateTime date = DateTime.Now;
            gameScript.lastComida = date.AddHours(-3);
            gameScript.lastDiversao = date.AddHours(-3);
            gameScript.lastAgua = date.AddHours(-3);
            gameScript.lastSujeira = date.AddHours(-3);
            gameScript.lastEnergia = date;
            gameScript.lastCagar = date.AddHours(-3);

            

        }
        else
        {
            foreach (Vector2 poopPos in gameScript.poops)
            {
                var bostacoco = Instantiate(bosta, transform.parent);
                bostacoco.transform.position = poopPos;
            }
        }

        var diarreia = true;
        do
        {
            diarreia = Pooping(PosRandom());
        } while (diarreia) ;
    }

    private void Update()
    {
        CheckStats();

        Pooping(transform.position);

        MachineState();


    }

    private Vector2 PosRandom()
    {
        float posx = Random.Range(-20f,20f);
        float yrange = (20-math.abs(posx))/2;
        float posy = Random.Range(-yrange, yrange);
        return new Vector2(posx,posy);
    }

    private bool Pooping(Vector2 pos)
    {
        var cagar = false;
        DateTime dat = DateTime.Now;
        DateTime datSemCagar = dat.AddTicks(-gameScript.lastCagar.Ticks);
        var horaspracagar = (datSemCagar.Hour) + (datSemCagar.Day * 24) + (datSemCagar.Month * 720) + (datSemCagar.Year * 8760) - 8760 - 720 - 24;
        if (stat_Comida == "Gordo")
        {
            if (horaspracagar >= 4)
            {
                gameScript.lastCagar = AddInHours(gameScript.lastCagar, 4);
                cagar = true;
            }
        }
        if (stat_Comida == "Cheio" || stat_Comida == "Neutro")
        {
            if (horaspracagar >= 8)
            {
                gameScript.lastCagar = AddInHours(gameScript.lastCagar, 8);
                cagar = true;
            }
        }
        if (cagar)
        {
            GameObject bostaInst = Instantiate(bosta, pos, Quaternion.identity);
            gameScript.poops.Add(bostaInst.transform.position);
            return true;
        }
        else return false;
    }


    private DateTime AddInHours(DateTime date, int hours)
    {
        if(hours>0)
        {
            DateTime datatemp = new DateTime();
            datatemp = datatemp.AddHours(hours);
            return date.AddTicks(datatemp.Ticks);
        }
        else
        {
            return date.AddHours(-120);
        }
    }


    private void MachineState()
    {
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

    private void CheckStats()
    {

        DateTime dat = DateTime.Now;

        DateTime datSemComida = dat.AddTicks(-gameScript.lastComida.Ticks);
        if (datSemComida.Hour < 3)
        {
            stat_Comida = "Gordo";
        }
        if (datSemComida.Hour >= 3)
        {
            stat_Comida = "Cheio";
        }
        if (datSemComida.Hour >= 6)
        {
            stat_Comida = "Neutro";
        }
        if (datSemComida.Hour >= 12)
        {
            stat_Comida = "Com Fome";
        }
        if (datSemComida.Hour >= 24)
        {
            stat_Comida = "Esfomeado";
        }
        if (datSemComida.Hour >= 72)
        {
            stat_Comida = "Morto - Fome";
        }

        DateTime datSemDiversao = dat.AddTicks(-gameScript.lastDiversao.Ticks);
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

        DateTime datSemAgua = dat.AddTicks(-gameScript.lastAgua.Ticks);
        if (datSemAgua.Hour < 3)
        {
            stat_Agua = "Cheio";
        }
        if (datSemAgua.Hour >= 8)
        {
            stat_Agua = "Neutro";
        }
        if (datSemAgua.Hour >= 16)
        {
            stat_Agua = "Com Sede";
        }
        if (datSemAgua.Hour >= 32)
        {
            stat_Agua = "Muita sede";
        }
        if (datSemAgua.Hour >= 72)
        {
            stat_Agua = "Morto - Sede";
        }

        DateTime datSemBanho = dat.AddTicks(-gameScript.lastSujeira.Ticks);
        if (datSemBanho.Hour < 3)
        {
            stat_Sujeira = "Brilhando";
        }
        if (datSemBanho.Hour >= 8)
        {
            stat_Sujeira = "Limpo";
        }
        if (datSemBanho.Hour >= 16)
        {
            stat_Sujeira = "Neutro";
        }
        if (datSemBanho.Hour >= 24)
        {
            stat_Sujeira = "Sujo";
        }
        if (datSemBanho.Hour >= 48)
        {
            stat_Sujeira = "Podre";
        }

        DateTime datSemEnergia = dat.AddTicks(-gameScript.lastEnergia.Ticks);
        if (datSemEnergia.Hour >= 1)
        {
            gameScript.energyPoints += 1;
            if (gameScript.energyPoints > 10) gameScript.energyPoints = 10;
            gameScript.lastEnergia = gameScript.lastEnergia.AddHours(1);
        }
    }
}


