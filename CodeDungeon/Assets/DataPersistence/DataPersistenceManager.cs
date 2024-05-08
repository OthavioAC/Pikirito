using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName = "SavePriquito.game";

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    private bool loaded = false;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null) 
        {
            Debug.LogError("Mais que um DataPersistence na cena");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        loaded = true;
        this.gameData = dataHandler.Load();
        if(this.gameData == null)
        {
            Debug.Log("Sem data, criando um novo jogo");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            Debug.Log("Jogo Carregado");
            dataPersistenceObj.LoadData(gameData);
        }
    }


    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        dataHandler.Save(gameData);
    }


    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void OnApplicationPause()
    {
        if(loaded) SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    //para chamar de outro script
    //DataPersistenceManager.instance.LoadGame();
}
