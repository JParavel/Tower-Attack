using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    private Cell cell;
    private int gCost;
    private int hCost;
    private int fCost;
    private PathNode lastNode;
}
