using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour, IDataPersistence
{

    public RawImage newEgg;
    public GameObject textOvo;
    public GameObject characterSet;

    public GameObject piriquito = null;
    [SerializeField] public DateTime lastComida;
    [SerializeField] public DateTime lastDiversao;
    [SerializeField] public DateTime lastAgua;
    [SerializeField] public DateTime lastSujeira;
    [SerializeField] public DateTime lastEnergia;
    [SerializeField] public DateTime lastCagar;
    [SerializeField] public int energyPoints = 10;
    [SerializeField] public List<GameObject> poops = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        newEgg.enabled = false;
        if (piriquito == null)
        {
            newEgg.enabled = true;
        }
        else
        {
            Instantiate(piriquito, transform.parent);
            textOvo.SetActive(false);
        }
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
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
