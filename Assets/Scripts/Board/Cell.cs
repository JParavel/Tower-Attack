using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public Entity entity;
    public Vector2 position;

    public Cell(Vector2 position)
    {
        this.position = position;
    }

    public bool HasEntity()
    {
        return entity != null;
    }
}
