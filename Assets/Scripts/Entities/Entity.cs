using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private EntityData _data;
    public EntityData data
    {
        get { return _data; }
        set
        {
            _data = value;
            UpdateData();
        }
    }

    [SerializeField] private SpriteRenderer _iconRenderer;
    [SerializeField] private SpriteRenderer _baseRenderer;
    private int _health;

    public void Damage(int damage)
    {
        int totalDamage = damage - _data.defense;
        if (totalDamage < 1) totalDamage = 1;
        _health -= totalDamage;
        if (_health <= 0) Kill();
    }

    public void Kill()
    {
        _health = 0;
        //WAIT FOR DEATH ANIMATION
        //VANISH PARTICLES
        Destroy(gameObject);
    }

    public void UpdateData()
    {
        _health = _data.health;
        _iconRenderer.sprite = _data.model;
    }

    public void SetBaseColor(Color color)
    {
        _baseRenderer.color = color;
    }
}
