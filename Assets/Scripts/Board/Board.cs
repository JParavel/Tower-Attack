using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    //Entities
    [SerializeField] private EntityManager entityManager;
    [SerializeField] private Entity entityPrefab;
    private List<Entity> topEntities;
    private List<Entity> botEntities;

    //Board properties
    [SerializeField] private SpriteRenderer boardRenderer;
    [SerializeField] private Vector2 _size;
    public Vector2 size { get { return _size; } }
    private PathGrid pathGrid;

    private void Start()
    {
        LoadBoard();
    }

    public void LoadBoard()
    {
        GenerateBoard();
        pathGrid = new PathGrid(this);
        topEntities = new List<Entity>();
        botEntities = new List<Entity>();
    }
    public void GenerateBoard()
    {
        boardRenderer.size = _size;
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
        if (randomizeEvent.side == BoardSide.TOP)
        {
            Entity nexus = PlaceEntity(entityManager.nexusData, BoardSide.TOP);
        }
    }

    public Entity PlaceEntity(EntityData entityData, BoardSide side)
    {

        PathNode node = pathGrid.GetEmptyNode(side);
        Vector2 position = pathGrid.GetWorldPosition(node);

        Entity entity = Instantiate(entityPrefab, position, Quaternion.identity, transform);
        entity.data = entityData;

        node.entity = entity;

        switch (side)
        {
            case BoardSide.TOP:
                topEntities.Add(entity);
                break;
            case BoardSide.BOT:
                botEntities.Add(entity);
                break;
        }

        return entity;
    }

    public void ClearSide(BoardSide side)
    {
        List<Entity> entities = botEntities;
        if (side == BoardSide.TOP)
        {
            entities = topEntities;
        }

        foreach (Entity entity in entities)
        {
            Destroy(entity.gameObject);
        }

        entities.Clear();
    }

}
