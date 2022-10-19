using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public EntityManager entityManager;

    public void UnitButtonClick()
    {
        entityManager.RandomizeUnits(entityManager.playerUnits, BoardSide.BOT);
    }

    public void TowerButtonClick()
    {
        entityManager.RandomizeUnits(entityManager.towerUnits, BoardSide.TOP);
    }
}
