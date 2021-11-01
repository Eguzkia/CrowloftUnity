using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class Tile : MonoBehaviour
{
    public bool IsOccupied, IsTarget;
    public int x, y;

    [SerializeField] private Color _baseColor, _targetColor;
    [SerializeField] private SpriteRenderer _renderer;


    private FsmBool _isTargetTile;

    private PlayMakerFSM fsm;

    public void Start()
    {
        fsm = this.GetComponent<PlayMakerFSM>();
        _isTargetTile = fsm.FsmVariables.GetFsmBool("IsTargetTile");
    }

    public void SetTarget()
    {
        this.IsTarget = true;
        _renderer.color = _targetColor;
        _isTargetTile.Value = true;
    }

    public void UnSetTarget()
    {
        this.IsTarget = false;
        _renderer.color = _baseColor;
        _isTargetTile.Value = false;
    }

    public Tile GetTile()
    {
        return this;
    }
}
