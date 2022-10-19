using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    public Entity entity;
    private int gCost;
    private int hCost;
    private int fCost;
    public Vector2 position { get; private set; }

    public PathNode(Vector2 position)
    {
        this.position = position;
    }

    public bool HasEntity()
    {
        return entity != null;
    }

}
