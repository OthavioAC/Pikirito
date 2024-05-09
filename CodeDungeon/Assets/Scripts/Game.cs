using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour, IDataPersistence
{ 
    public Camera cam; 
    public Image newEgg;
    public GameObject textMoedas;
    public GameObject tijela;
    public GameObject cenario;
    public GameObject HudMinigames;

    public GameObject piriquito = null;
    public GameObject piriquitoObj = null;
    [SerializeField] public DateTime lastComida;
    [SerializeField] public DateTime lastDiversao;
    [SerializeField] public DateTime lastAgua;
    [SerializeField] public DateTime lastSujeira;
    [SerializeField] public DateTime lastEnergia;
    [SerializeField] public DateTime lastCagar;
    [SerializeField] public int energyPoints = 10;
    [SerializeField] public bool tijelaEnxida = false;
    [SerializeField] public List<Vector2> poops = new List<Vector2>();
    [SerializeField] public int moedas = 0;
    [SerializeField] public List<int> FoodCount = new List<int>();

    public List<GameObject> CocosInScreen = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ToStart()
    {
        newEgg.enabled = false;
        if (piriquito == null)
        {
            newEgg.enabled = true;
        }
        else
        {
            if (piriquito.tag == "Passarinho")
            {
                piriquito.GetComponent<Character>().gameObjecte = this.gameObject;
            }
            piriquitoObj = Instantiate(piriquito, cenario.transform);
        }

        IniatilizeFoodCount();
    }

    public void IniatilizeFoodCount()
    {
        if(FoodCount.Count == 0) 
        {
            FoodCount.Add(3); //Cenoura
        }

        //Se adicionar novas comidas deixa 0 automaticamente, só mudar o o valor pra quantidade desejada
        while (FoodCount.Count < 1)
        {
            FoodCount.Add(0);
        }
    }

    public void EncherTijela()
    {
        if(!tijelaEnxida)
        {
            tijelaEnxida = true;
        }
    }

    public void InitAgua()
    {
        tijela.GetComponent<Vazilha>().StartTijela(tijelaEnxida);
    }

    public void BebeuAgua()
    {
        tijelaEnxida = false;
        tijela.GetComponent<SpriteRenderer>().sprite = tijela.GetComponent<Vazilha>().poteVazio;
    }

    public void LoadData(GameData data)
    {
        this.lastComida = DateTime.ParseExact(data.lastComida, "yyyyMMdd-HHmmss",CultureInfo.InvariantCulture);
        this.lastSujeira = DateTime.ParseExact(data.lastSujeira, "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
        this.lastEnergia = DateTime.ParseExact(data.lastEnergia, "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
        this.lastAgua = DateTime.ParseExact(data.lastAgua, "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
        this.lastDiversao = DateTime.ParseExact(data.lastDiversao, "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
        this.lastCagar = DateTime.ParseExact(data.lastCagar, "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
        this.piriquito = data.piriquito;
        this.energyPoints = data.energyPoints;
        this.poops = data.poops;
        this.moedas = data.moedas;
        this.FoodCount = data.FoodCount;
        this.tijelaEnxida = data.tijelaEnxida;
        ToStart();
    }

    public void SaveData(ref GameData data)
    {
        data.lastComida = this.lastComida.ToString("yyyyMMdd-HHmmss");
        data.lastSujeira = this.lastSujeira.ToString("yyyyMMdd-HHmmss");
        data.lastEnergia = this.lastEnergia.ToString("yyyyMMdd-HHmmss");
        data.lastAgua = this.lastAgua.ToString("yyyyMMdd-HHmmss");
        data.lastDiversao = this.lastDiversao.ToString("yyyyMMdd-HHmmss");
        data.lastCagar = this.lastAgua.ToString("yyyyMMdd-HHmmss");
        data.piriquito = this.piriquito;
        data.energyPoints = this.energyPoints;
        data.poops = this.poops;
        data.moedas = this.moedas;
        data.FoodCount = this.FoodCount;
        data.tijelaEnxida = this.tijelaEnxida;
    }


    // Update is called once per frame
    void Update()
    {
        if(moedas !=null) textMoedas.GetComponent<TextMeshProUGUI>().text = moedas.ToString();
    }
}
