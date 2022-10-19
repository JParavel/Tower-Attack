using UnityEngine;

[CreateAssetMenu(fileName = "NewEntity", menuName = "Tower Attack/Entity", order = 0)]
public class EntityData : ScriptableObject {
    public Sprite model;
    public Color baseColor;
    public int cost;
    public int health;
    public int defense;
    public int damage;
    public float attackSpeed;
}
