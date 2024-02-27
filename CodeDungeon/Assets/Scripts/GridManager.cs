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
                        case "mt_Parede1_Wall": tileprefab = Resources.Load<Tile>("Map/Tile_Parede1_Wall"); break;
                        case "mt_Parede1_Hover": tileprefab = Resources.Load<Tile>("Map/Tile_Parede1_Hover"); break;
                        default: break;
                    }
                    //Debug.Log(tileprefab);
                    if (tileprefab!=null)
                    {
                        var spawnedTile = Instantiate(tileprefab, new Vector3(x, y,0), Quaternion.identity);
                        spawnedTile.name = $"Tile {x} {y}";
                        var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                        spawnedTile.Init(isOffset, blockRawImage);
                        spawnedTile.GetComponent<SpriteRenderer>().sortingOrder = 0;
                        tilesMap[new Vector2(x, y)] = spawnedTile;
                    }
                }
            }
            //for que verifica o isParede e seta o sprite correto
            foreach (var tile in tilesMap)
            {
                bool bolleft = false;
                bool bolright = false;
                bool bolup = false;
                //funçao que ve script do TileType e checa o tipo
                if(tile.Value.GetComponent<Tile>().GetTileType()=="Wall")
                {
                    Sprite[] sprites = tile.Value.GetComponent<Tile>().GetSprites();
                    if (tilesMap.TryGetValue(new Vector2(tile.Key.x + 1, tile.Key.y), out var rightTile))
                    {
                        if (rightTile.GetComponent<Tile>().GetTileType() == "Wall"|| rightTile.GetComponent<Tile>().GetTileType() == "Hover")
                        {
                           bolright = true;
                        }
                    }
                    if (tilesMap.TryGetValue(new Vector2(tile.Key.x - 1, tile.Key.y), out var leftTile))
                    {
                        if (leftTile.GetComponent<Tile>().GetTileType() == "Wall"|| leftTile.GetComponent<Tile>().GetTileType() == "Hover")
                        {
                            bolleft = true;
                        }
                    }
                    if(bolright&&bolleft) tile.Value.GetComponent<SpriteRenderer>().sprite = sprites[2];
                    if(bolright&&!bolleft) tile.Value.GetComponent<SpriteRenderer>().sprite = sprites[1];
                    if(!bolright&&bolleft) tile.Value.GetComponent<SpriteRenderer>().sprite = sprites[3];
                    if(!bolright&&!bolleft) tile.Value.GetComponent<SpriteRenderer>().sprite = sprites[0];

                }
                if (tile.Value.GetComponent<Tile>().GetTileType() == "Hover")
                {
                    Sprite[] sprites = tile.Value.GetComponent<Tile>().GetSprites();
                    if (tilesMap.TryGetValue(new Vector2(tile.Key.x + 1, tile.Key.y), out var rightTile))
                    {
                        if (rightTile.GetComponent<Tile>().GetTileType() == "Hover")
                        {
                            bolright = true;
                        }
                    }
                    if (tilesMap.TryGetValue(new Vector2(tile.Key.x - 1, tile.Key.y), out var leftTile))
                    {
                        if (leftTile.GetComponent<Tile>().GetTileType() == "Hover")
                        {
                            bolleft = true;
                        }
                    }
                    if (tilesMap.TryGetValue(new Vector2(tile.Key.x, tile.Key.y + 1), out var upTile))
                    {
                        if (upTile.GetComponent<Tile>().GetTileType() == "Hover")
                        {
                            bolup = true;
                        }
                    }
                    if (bolright && !bolleft && !bolup) tile.Value.GetComponent<SpriteRenderer>().sprite = sprites[0];
                    if (bolright && bolleft && !bolup) tile.Value.GetComponent<SpriteRenderer>().sprite = sprites[1];
                    if (bolright && !bolleft && bolup) tile.Value.GetComponent<SpriteRenderer>().sprite = sprites[2];
                    if (bolright && bolleft && bolup) tile.Value.GetComponent<SpriteRenderer>().sprite = sprites[3];
                    if (!bolright && bolleft && bolup) tile.Value.GetComponent<SpriteRenderer>().sprite = sprites[4];
                    if (!bolright && bolleft && !bolup) tile.Value.GetComponent<SpriteRenderer>().sprite = sprites[5];
                    if (!bolright && !bolleft && !bolup) tile.Value.GetComponent<SpriteRenderer>().sprite = sprites[6];
                    if (!bolright && !bolleft && bolup) tile.Value.GetComponent<SpriteRenderer>().sprite = sprites[7];
                }
                if (tile.Value.GetComponent<Tile>().GetTileType() == "Chao")
                {
                    Sprite[] sprites = tile.Value.GetComponent<Tile>().GetSprites();
                    if ((tile.Key.x+tile.Key.y) % 2 == 0) tile.Value.GetComponent<SpriteRenderer>().sprite = sprites[0];
                    else tile.Value.GetComponent<SpriteRenderer>().sprite = sprites[1];
                }   

}           height = matrix.GetLength(1);
            width = matrix.GetLength(0);
            cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
            cam.GetComponent<CameraMovement>().Restart();
        }
        if (type == "Objects")
        {
            tilesObjects = new Dictionary<Vector2, Tile>();
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    Tile tileprefab = null;
                    switch (matrix[x, y])
                    {
                        case "mt_CharacterKnight": tileprefab = Resources.Load<Tile>("Objects/Tile_CharacterKnight"); break;
                        case "mt_EnemySkeleton": tileprefab = Resources.Load<Tile>("Objects/Tile_EnemySkeleton"); break;
                        case "mt_ObjectTorch1": tileprefab = Resources.Load<Tile>("Objects/Tile_ObjectTorch1"); break;
                        default: break;
                    }
                    //Debug.Log(tileprefab);
                    if (tileprefab != null)
                    {
                        var spawnedTile = Instantiate(tileprefab, new Vector3(x, y, 1), Quaternion.identity);
                        spawnedTile.name = $"Tile {x} {y}";
                        var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                        spawnedTile.Init(isOffset, blockRawImage);
                        spawnedTile.GetComponent<SpriteRenderer>().sortingOrder = 1;
                        tilesObjects[new Vector2(x, y)] = spawnedTile;
                    }
                }
            }
        }
    }
}
