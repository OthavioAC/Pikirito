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
        String[,] matrixMap = setMatrixMap(maptile,true);
        String[,] matrixObject = setMatrixMap(mapobjects,false);
        maptile.ClearAllTiles();
        mapobjects.ClearAllTiles();  
        gridManager.GetComponent<GridManager>().SetLay(matrixMap,"Map");
        gridManager.GetComponent<GridManager>().SetLay(matrixObject,"Objects");
        gridManager.SetActive(true);
    }

    private String[,] setMatrixMap(Tilemap tilemap, bool flag)
    {
        tilemap.CompressBounds();
        //reconhecer o tileset do mapa e voltar matrix
        gridObject.transform.position = new Vector3(-maptile.cellBounds.xMin, -maptile.cellBounds.yMin, 0);
        var maptilematrix = new String[maptile.cellBounds.size.x, maptile.cellBounds.size.y];
        for (int x = maptile.cellBounds.xMin; x < maptile.cellBounds.xMax; x++)
        {
            for (int y = maptile.cellBounds.yMin; y < maptile.cellBounds.yMax; y++)
            {
                Vector3Int localPlace = new Vector3Int(x, y, (int)maptile.transform.position.z);
                Vector3 place = maptile.CellToWorld(localPlace);
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
