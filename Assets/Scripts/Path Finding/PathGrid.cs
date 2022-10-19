using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGrid
{
    private Board board;
    private PathNode[,] nodes;

    public PathGrid(Board board)
    {
        this.board = board;

        Vector2 size = board.size;
        nodes = new PathNode[(int)size.x, (int)size.y];

        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                nodes[x, y] = new PathNode(new Vector2(x, y));
            }
        }
    }

    public PathNode GetEmptyNode(BoardSide side)
    {
        PathNode node;
        do
        {
            node = GetRandomNode(side);
        } while (node.HasEntity());
        return node;
    }

    public PathNode GetRandomNode(BoardSide side)
    {
        Vector2 size = board.size;
        int x = Random.Range(0, (int)size.x);
        int y = Random.Range(0, (int)size.y / 3);

        if (side == BoardSide.TOP)
        {
            y += 2 * (int)size.y / 3;
        }
        return nodes[x, y];
    }

    public Vector2 GetWorldPosition(PathNode node)
    {
        Vector2 size = board.size;
        return node.position - size / 2f + Vector2.one / 2f + (Vector2)board.transform.position;
    }
}
