using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    public string name = "Bob";
    public GameObject gameObjecte;
    public Game gameScript;
    public GameObject label_moedas;
    public Animator anim;
    public GameObject bosta;
    public GameObject balao;
    public GameObject banhoPart;
    public GameObject sujoPart;

    public List<ParticleSystem> emotesPart = new List<ParticleSystem>();

    public float velocidade = 5f; // Velocidade de movimento
    public Vector2 limiteMin; // Canto inferior esquerdo da área
    public Vector2 limiteMax; // Canto superior direito da área

    public string state = "Idle";


    private float idleTime = 0;
    private float idleTimeMax = 4;
    private Vector2 lastPos = new Vector2(0, 0);
    private Vector2 walkingTo = new Vector2(0, 0);
    private float balaoTime = 0;
    private float balaoTimeMax = 4;

    private Vector2 destinoAleatorio;


    [SerializeField] private string stat_Comida = "Cheio";
    [SerializeField] private string stat_Diversao = "Muito Feliz";
    [SerializeField] private string stat_Agua = "Cheio";
    [SerializeField] private string stat_Sujeira = "Limpo";


    private void Start()
    {
        banhoPart.GetComponent<ParticleSystem>().Pause();
        sujoPart.GetComponent<ParticleSystem>().Pause();
        emotesPart[0].Stop();
        emotesPart[1].Stop();
        emotesPart[2].Stop();
        gameScript = gameObjecte.GetComponent<Game>();
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
            gameScript.InitAgua();
            if (gameScript.tijelaEnxida)
            {
                DateTime dat = DateTime.Now;
                DateTime datSemAguaDate = dat.AddTicks(-gameScript.lastAgua.Ticks);
                int datSemAgua = (datSemAguaDate.Hour) + (datSemAguaDate.Day * 24) + (datSemAguaDate.Month * 720) + (datSemAguaDate.Year * 8760) - 8760 - 720 - 24;
                if(datSemAgua>=8)
                {
                    gameScript.BebeuAgua();
                    gameScript.lastAgua = gameScript.lastAgua.AddHours(8);
                }
            }
            foreach (Vector2 poopPos in gameScript.poops)
            {
                bosta.GetComponent<Bosta>().game = gameObjecte.gameObject;
                var bostacoco = Instantiate(bosta, transform.parent);
                bostacoco.transform.position = poopPos;
                gameScript.CocosInScreen.Add(bostacoco);
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

        CheckIfFedido();

        CheckIfSede();

        Pooping(transform.position);

        CheckBalao();

        MachineState();

    }

    private Vector2 PosRandom()
    {
        float posx = Random.Range(-20f,20f);
        float yrange = (20-math.abs(posx))/2;
        float posy = Random.Range(-yrange, yrange);
        return new Vector2(posx,posy);
    }


    private void CheckIfSede()
    {
        if (stat_Agua == "Muita Sede" ||
            stat_Agua == "Com Sede" ||
            stat_Agua == "Morto - Sede")
        {

            if (gameScript.tijelaEnxida)
            {
                state = "Beber Agua";
            }
        }

    }
    private void CheckIfFedido()
    {
        if (stat_Sujeira=="Podre"|| stat_Sujeira == "Sujo")
        {
            if(!sujoPart.GetComponent<ParticleSystem>().isPlaying)
            {
                sujoPart.GetComponent<ParticleSystem>().Play();
            }
        }
        else
        {
            sujoPart.GetComponent<ParticleSystem>().Stop();
        }
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
        else if (stat_Comida == "Cheio" || stat_Comida == "Neutro")
        {
            if (horaspracagar >= 8)
            {
                gameScript.lastCagar = AddInHours(gameScript.lastCagar, 8);
                cagar = true;
            }
        }
        if (cagar)
        {
            bosta.GetComponent<Bosta>().game = gameObjecte.gameObject;
            GameObject bostaInst = Instantiate(bosta, pos, Quaternion.identity,gameObjecte.transform);
            gameScript.poops.Add(bostaInst.transform.position);
            gameScript.CocosInScreen.Add(bostaInst);
            emotesPart[1].Play();
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
        if(state=="Beber Agua")
        {
            anim.SetBool("Idle", false);
            var posx = transform.position.x - gameScript.tijela.transform.position.x;
            var posy = transform.position.y - gameScript.tijela.transform.position.y;
            anim.SetFloat("MovementX", -posx);
            anim.SetFloat("MovementY", -posy);
            transform.position = Vector2.MoveTowards(transform.position, gameScript.tijela.transform.position, velocidade * Time.deltaTime);
            float dist = Vector2.Distance(transform.position, gameScript.tijela.transform.position);
            if(dist < 1)
            {
                gameScript.BebeuAgua();
                gameScript.lastAgua = gameScript.lastAgua.AddHours(8);
                idleTime = 0;
                emotesPart[1].Play();
                state = "Idle";
            }
        }
    }



    private bool CheckBalao()
    {
        var statename = "none";
        if (balaoTime <= balaoTimeMax)
        {
            balaoTime += Time.deltaTime;
            return false;
        }
        balaoTime = 0;
        List<String> stats = new List<String>();
        if (stat_Comida == "Com Fome" ||
            stat_Comida == "Esfomeado" ||
            stat_Comida == "Morto - Fome")
        {
            statename = "food";
            stats.Add(stat_Comida);
        }

        /*
        if (stat_Diversao == "Triste" ||
            stat_Diversao == "Depressivo")
        {
            stats.Add(stat_Diversao);
        }
        
        if (gameScript.energyPoints <= 0)
        {
            stats.Add("Cansado");
        }
        */

        if (stat_Agua == "Muita Sede" ||
            stat_Agua == "Com Sede" ||
            stat_Agua == "Morto - Sede")
        {
            stats.Add(stat_Agua);
            statename = "sede";
        }

        if (stat_Sujeira == "Podre" ||
            stat_Sujeira == "Sujo")
        {
            statename = "sujo";
            stats.Add(stat_Sujeira);
        }

        if(stats.Count > 0)
        {

            emotesPart[2].Play();
            var balaoObj = balao;
            balaoObj.GetComponent<Balao>().iconName = statename;
            Instantiate(balaoObj, transform);
        }
        return true;
    }
    private void CheckStats()
    {

        DateTime dat = DateTime.Now;


        DateTime datSemComidaDate = dat.AddTicks(-gameScript.lastComida.Ticks);
        int datSemComida = (datSemComidaDate.Hour) + (datSemComidaDate.Day * 24) + (datSemComidaDate.Month * 720) + (datSemComidaDate.Year * 8760) - 8760 - 720 - 24;
        if (datSemComida >= 72) stat_Comida = "Morto - Fome";
        else if (datSemComida>= 24) stat_Comida = "Esfomeado";
        else if (datSemComida >= 12) stat_Comida = "Com Fome";
        else if (datSemComida >= 6) stat_Comida = "Neutro";
        else if (datSemComida >= 3) stat_Comida = "Cheio";
        else if (datSemComida < 3) stat_Comida = "Gordo";

        DateTime datSemDiversaoDate = dat.AddTicks(-gameScript.lastDiversao.Ticks);
        int datSemDiversao = (datSemDiversaoDate.Hour) + (datSemDiversaoDate.Day * 24) + (datSemDiversaoDate.Month * 720) + (datSemDiversaoDate.Year * 8760) - 8760 - 720 - 24;
        if (datSemDiversao >= 32) stat_Diversao = "Depressivo";
        else if (datSemDiversao >= 16) stat_Diversao = "Triste";
        else if (datSemDiversao >= 8) stat_Diversao = "Neutro";
        else if (datSemDiversao >= 3) stat_Diversao = "Feliz";
        else if (datSemDiversao < 3) stat_Diversao = "Excitado";

        DateTime datSemAguaDate = dat.AddTicks(-gameScript.lastAgua.Ticks);
        int datSemAgua = (datSemAguaDate.Hour) + (datSemAguaDate.Day * 24) + (datSemAguaDate.Month * 720) + (datSemAguaDate.Year * 8760) - 8760 - 720 - 24;
        if (datSemAgua >= 72) stat_Agua = "Morto - Sede";
        else if (datSemAgua>= 32) stat_Agua = "Muita Sede";
        else if (datSemAgua >= 16) stat_Agua = "Com Sede";
        else if (datSemAgua >= 8) stat_Agua = "Neutro";
        else if (datSemAgua < 3) stat_Agua = "Cheio";

        DateTime datSemBanhoDate = dat.AddTicks(-gameScript.lastSujeira.Ticks);
        int datSemBanho = (datSemBanhoDate.Hour) + (datSemBanhoDate.Day * 24) + (datSemBanhoDate.Month * 720) + (datSemBanhoDate.Year * 8760) - 8760 - 720 - 24;
        if (datSemBanho >= 48) stat_Sujeira = "Podre";
        else if (datSemBanho >= 24) stat_Sujeira = "Sujo";
        else if (datSemBanho >= 16) stat_Sujeira = "Neutro";
        else if (datSemBanho >= 8) stat_Sujeira = "Limpo";
        else if (datSemBanho < 3) stat_Sujeira = "Brilhando";

        DateTime datSemEnergiaDate = dat.AddTicks(-gameScript.lastEnergia.Ticks);
        int datSemEnergia = (datSemEnergiaDate.Hour) + (datSemEnergiaDate.Day * 24) + (datSemEnergiaDate.Month * 720) + (datSemEnergiaDate.Year * 8760) - 8760 - 720 - 24;
        if (datSemEnergia >= 1)
        {
            gameScript.energyPoints += 1;
            if (gameScript.energyPoints > 10) gameScript.energyPoints = 10;
            gameScript.lastEnergia = gameScript.lastEnergia.AddHours(1);
        }
    }
}


