using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomizeEvent", menuName = "Event System/RandomizeEvent", order = 0)]
public class RandomizeEvent : GameEvent
{
    [HideInInspector] public BoardSide side;
}
