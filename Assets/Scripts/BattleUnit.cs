using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] public GameObject _grid;
    [SerializeField] private int _move;

    public Tile _currentTile;

    private FsmGameObject _targetTile;

    public void SetStartingTile(Vector2 startingTile)
    {
        Debug.Log("Enter set start.");
        _currentTile = _grid.GetComponent<GridManager>().GetTile(startingTile);

        Debug.Log(_grid.GetComponent<GridManager>()._tiles.Count);
        Debug.Log(_currentTile);
        this.transform.position = _currentTile.transform.position;

        Debug.Log("Set start.");

        _currentTile.IsOccupied = true;

    }

    public void SetCurrentTile(int x, int y)
    {
        _currentTile = _grid.GetComponent<GridManager>().GetTile(new Vector2(x,y));
    }

    public void GetTargetTiles(int range)
    {
        _grid.GetComponent<GridManager>().TargetTiles(_currentTile, range);
    }

    public void Move()
    {
        _currentTile.IsOccupied = false;
        _targetTile = FsmVariables.GlobalVariables.GetFsmGameObject("ClickedTile");

        GameObject moveTile = _targetTile.Value;

        if(moveTile.GetComponent<Tile>().IsTarget)
        {
            this._currentTile = moveTile.GetComponent<Tile>().GetTile();
        }

        _currentTile.IsOccupied = true;
    }
}
