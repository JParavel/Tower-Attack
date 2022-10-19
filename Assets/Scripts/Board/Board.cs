using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Entity entityPrefab;
    [SerializeField] private SpriteRenderer boardRenderer;
    [SerializeField] private Vector2 size;
    [SerializeField] private Vector2 cellSize;

    private Cell[,] cells;

    private void Start()
    {
        LoadBoard();
    }

    public void LoadBoard()
    {
        GenerateBoard();
        cells = new Cell[(int)size.x, (int)size.y];

        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                cells[x, y] = new Cell(new Vector2(x, y));
            }
        }
    }
    public void GenerateBoard()
    {
        boardRenderer.size = size;
    }

    public void OnSummonEntity(GameEvent e)
    {
        SummonEntityEvent summonEntityEvent = (SummonEntityEvent)e;
        EntityData entityData = summonEntityEvent.entityData;
        BoardSide boardSide = summonEntityEvent.boardSide;
        PlaceEntity(entityData, boardSide);
    }

    public void OnRandomizeEvent(GameEvent e)
    {
        RandomizeEvent randomizeEvent = (RandomizeEvent)e;
        ClearSide(randomizeEvent.side);
    }

    public void PlaceEntity(EntityData entityData, BoardSide side)
    {
        Cell cell;
        do
        {
            cell = GetRandomCell(side);
        } while (cell.HasEntity());

        Vector2 position = CellToWorldSpace(cell);
        Entity entity = Instantiate(entityPrefab, position, Quaternion.identity, transform);
        entity.data = entityData;
        cell.entity = entity;
    }

    private Cell GetRandomCell(BoardSide side)
    {
        int x = Random.Range(0, (int)size.x);
        int y = Random.Range(0, (int)size.y / 3);

        if (side == BoardSide.TOP)
        {
            y += 2 * (int)size.y / 3;
        }
        return cells[x, y];
    }

    private Vector2 CellToWorldSpace(Cell cell)
    {
        return cell.position - size / 2f + cellSize / 2f + (Vector2)transform.position;
    }

    public void ClearSide(BoardSide side)
    {
        foreach (Cell cell in cells)
        {
            if (!cell.HasEntity()) continue;

            if (side == BoardSide.TOP && cell.position.y > size.y / 2f)
            {
                Destroy(cell.entity.gameObject);
            }
            else if (side == BoardSide.BOT && cell.position.y < size.y / 2f)
            {
                Destroy(cell.entity.gameObject);
            }
        }

    }

}
