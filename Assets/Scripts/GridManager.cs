using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;

    public List<Tile> _tiles;

    void Awake()
    {
        GenerateGrid();
    }
    void GenerateGrid()
    {
        Debug.Log("Enter generate grid");
        _tiles = new List<Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(-3.3f + x*2, -4.2f + y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.x = x;
                spawnedTile.y = y;

                _tiles.Add(spawnedTile);
            }
        }
    }

    public Tile GetTile(Vector2 position)
    {
        foreach(Tile tile in _tiles)
        {
            if(tile.x == position.x && tile.y == position.y)
            {
                return tile;
            }
        }

        return null;
    }

    public void TargetTiles(Tile originTile, int range)
    {
        foreach(Tile tile in _tiles)
        {
            if(tile.x < 2 && !tile.IsOccupied)
            {
                if((Mathf.Abs(originTile.x - tile.x) <= range) && (originTile.y == tile.y))
                {
                    tile.SetTarget();
                }

                if((Mathf.Abs(originTile.y - tile.y) <= range) && (originTile.x == tile.x))
                {
                    tile.SetTarget();
                }
            }

        }
    }

    public void UntargetTiles()
    {
        foreach(Tile tile in _tiles)
        {
            tile.UnSetTarget();
        }
    }
}
