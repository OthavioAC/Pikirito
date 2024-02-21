using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class MapLayoults : MonoBehaviour
{
    [SerializeField] private int layId;
    [SerializeField] private GameObject gridManager;
    [SerializeField] private GameObject maptile;

    // Start is called before the first frame update
    void Start()
    {
        int[,] layMatrix = setMatrix();
        int mapSizeX = layMatrix.GetLength(0);
        int mapSizeY = layMatrix.GetLength(1);
        maptile.SetActive(false);
        gridManager.GetComponent<GridManager>().SetLay(layMatrix, mapSizeX, mapSizeY);
        gridManager.SetActive(true);
    }

    private int[,] setMatrix()
    {
        //reconhecer o tileset do mapa e voltar matrix
        return new int[5,4];
    }

}
