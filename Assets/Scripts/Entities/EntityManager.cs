using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EntityManager", menuName = "Tower Attack/EntityManager", order = 0)]
public class EntityManager : ScriptableObject
{

    public SummonEntityEvent summonEntityEvent;
    public RandomizeEvent randomizeEvent;
    public int maxCost;

    public EntityData nexusData;
    public List<EntityData> towerUnits = new List<EntityData>();
    public List<EntityData> playerUnits = new List<EntityData>();

    private EntityData GetRandomUnit(List<EntityData> units)
    {
        return units[Random.Range(0, units.Count)];
    }

    public void RandomizeUnits(List<EntityData> units, BoardSide side)
    {
        randomizeEvent.side = side;
        if (!randomizeEvent.Execute()) return;
        
        int currentCost = 0;

        while (currentCost < maxCost)
        {
            EntityData entityData = GetRandomUnit(units);
            if (currentCost + entityData.cost <= maxCost)
            {
                summonEntityEvent.entityData = entityData;
                summonEntityEvent.boardSide = side;

                if (summonEntityEvent.Execute())
                {
                    currentCost += entityData.cost;
                }
            }
        }
    }
}
