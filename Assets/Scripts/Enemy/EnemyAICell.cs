using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cell
{
    public Vector3Int position;

    public double cost, heuristic;
    public double f
    {
        get { return cost + heuristic; }
    }

    public Cell parent;


    public Cell() { }

    public Cell(Vector3Int position)
    {
        this.position = position;
    }
}
