using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public EntityManager entityManager;

    public void OnUnitsButtonClick(){
        entityManager.RandomizeUnits(entityManager.towerUnits, BoardSide.TOP);
        entityManager.RandomizeUnits(entityManager.playerUnits, BoardSide.BOT);
    }
}
