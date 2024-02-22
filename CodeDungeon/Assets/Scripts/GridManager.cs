using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.WSA;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Transform cam;
    [SerializeField] private GameObject blockRawImage;

    private Dictionary<Vector2, Tile> tilesMap;
    private Dictionary<Vector2, Tile> tilesObjects;

    private void Start()
    {
        //GenerateGrid();
    }
    /*
    void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset, blockRawImage);
                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
        cam.GetComponent<CameraMovement>().Restart();
    }
    */
    public Tile GetTilePosition(Vector2 pos)
    {
        if (tilesMap.TryGetValue(pos, out var tile))
        {
            return tile;
        }
        return null;
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public void SetLay(string[,] matrix, string type)
    {
        if (type == "Map")
        {
            tilesMap = new Dictionary<Vector2, Tile>();
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    Tile tileprefab = null;
                    switch (matrix[x, y])
                    {
                        case "mt_Chao1": tileprefab = Resources.Load<Tile>("Map/Tile_Chao1");  break;
                        case "mt_Parede1": tileprefab = Resources.Load<Tile>("Map/Tile_Parede1"); break;
                        default: break;
                    }
                    Debug.Log(tileprefab);
                    if (tileprefab!=null)
                    {
                        var spawnedTile = Instantiate(tileprefab, new Vector3(x, y), Quaternion.identity);
                        spawnedTile.name = $"Tile {x} {y}";
                        var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                        spawnedTile.Init(isOffset, blockRawImage);
                        tilesMap[new Vector2(x, y)] = spawnedTile;
                    }
                }
            }
            height = matrix.GetLength(1);
            width = matrix.GetLength(0);
            cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
            cam.GetComponent<CameraMovement>().Restart();
        }
        if (type == "Object")
        {

        }
    }
}
