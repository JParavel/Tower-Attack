using UnityEngine;

[CreateAssetMenu(fileName = "SummonEntityEvent", menuName = "Event System/SummonEntityEvent", order = 0)]
public class SummonEntityEvent : GameEvent {
    [HideInInspector] public EntityData entityData;
    [HideInInspector] public BoardSide boardSide;
}
