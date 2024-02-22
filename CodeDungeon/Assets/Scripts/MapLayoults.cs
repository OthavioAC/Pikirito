using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLayoults : MonoBehaviour
{
    [SerializeField] private int layId;
    [SerializeField] private GameObject gridManager;
    [SerializeField] private GameObject gridObject;
    [SerializeField] private Tilemap maptile;
    [SerializeField] private Tilemap mapobjects;

    // Start is called before the first frame update
    void Start()
    {
        String[,] matrixMap = setMatrixMap(maptile);
        String[,] matrixObject = setMatrixMap(mapobjects);
        maptile.ClearAllTiles();
        mapobjects.ClearAllTiles();  
        gridManager.GetComponent<GridManager>().SetLay(matrixMap,"Map");
        gridManager.GetComponent<GridManager>().SetLay(matrixObject,"Objects");
        gridManager.SetActive(true);
    }

    private String[,] setMatrixMap(Tilemap tilemap)
    {
        //reconhecer o tileset do mapa e voltar matrix
        tilemap.CompressBounds();
        gridObject.transform.position = new Vector3(-tilemap.cellBounds.xMin, -tilemap.cellBounds.yMin, 0);
        var maptilematrix = new String[tilemap.cellBounds.size.x, tilemap.cellBounds.size.y];
        for (int x = tilemap.cellBounds.xMin; x < tilemap.cellBounds.xMax; x++)
        {
            for (int y = tilemap.cellBounds.yMin; y < tilemap.cellBounds.yMax; y++)
            {
                Vector3Int localPlace = new Vector3Int(x, y, (int)tilemap.transform.position.z);
                Vector3 place = tilemap.CellToWorld(localPlace);
                if (tilemap.GetTile(localPlace) == null)
                {
                    maptilematrix[((int)place.x), ((int)place.y)] = "none";
                }
                else
                {
                    maptilematrix[((int)place.x), ((int)place.y)] = tilemap.GetTile(localPlace).name;
                }
                //Debug.Log(maptilematrix[((int)place.x), ((int)place.y)]);
            }
        }
        return maptilematrix;
    }


}
